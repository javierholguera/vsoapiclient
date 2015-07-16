using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using VsoApi.Contracts.Models;
using VsoApi.Contracts.Requests;
using VsoApi.Contracts.Requests.WIT;
using VsoApi.Contracts.Responses;
using VsoApi.Contracts.Responses.WIT;

namespace VsoApi.Client.Builders
{
    public class WorkItemCreateRequestBuilder
    {
        private readonly VsoClient _client;
        private readonly IDictionary<string, ICollection<WorkItemFieldInfo>> _fieldsInfoPerProject;

        public WorkItemCreateRequestBuilder(VsoClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");
            
            _client = client;
            _fieldsInfoPerProject = new Dictionary<string, ICollection<WorkItemFieldInfo>>();
        }
        
        public WorkItemCreateRequest Create(string project, WorkItem workItem, IEnumerable<FieldEntry> relations = null)
        {
            if (project == null)
                throw new ArgumentNullException("project");
            if (workItem == null)
                throw new ArgumentNullException("workItem");

            if (string.IsNullOrWhiteSpace(project))
                throw new ArgumentException("Project name is mandatory to create a new work item", "project");
            if (workItem.Fields == null)
                throw new ArgumentException("A workitem without fields cannot be created");
            if (string.IsNullOrWhiteSpace(workItem.Fields.SystemWorkItemType))
                throw new ArgumentException("The workItem has to define its type before been created (field SystemWorkItemType)");

            List<WorkItemFieldEntry> entries = workItem.Fields
                .GetType()
                .GetProperties()
                .Select(prop => GetFieldEntry(prop, workItem))
                .Where(field => field != null)
                .ToList();

            CheckNoReadOnlyFields(project, entries);

            IEnumerable<FieldEntry> info = relations != null 
                ? entries.Select(e => e.FieldEntry).Concat(relations).ToList() 
                : entries.Select(e => e.FieldEntry).ToList();

            return new WorkItemCreateRequest(project, workItem.Fields.SystemWorkItemType, info);
        }

        private void CheckNoReadOnlyFields(string project, IEnumerable<WorkItemFieldEntry> workItemFieldEntries)
        {
            if (_fieldsInfoPerProject.ContainsKey(project) == false) {
                CollectionResponse<WorkItemFieldInfo> response = _client.FieldResources.GetAll(new EmptyRequest());
                _fieldsInfoPerProject.Add(project, response.Value.ToArray());
            }

            StringBuilder errorLog = new StringBuilder();

            ICollection<WorkItemFieldInfo> fieldsInfo = _fieldsInfoPerProject[project];
            foreach (WorkItemFieldEntry wiFieldEntry in workItemFieldEntries) {
                
                FieldEntry entry = wiFieldEntry.FieldEntry;
                WorkItemFieldInfo result = fieldsInfo.SingleOrDefault(fieldInfo => fieldInfo.ReferenceName == entry.PropertyName);
                if (result == null) {
                    errorLog.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "There is no field info for field with name {0} and value {1}",
                        entry.PropertyName,
                        entry.Value ?? string.Empty);
                    errorLog.AppendLine();
                    continue;
                }

                if (result.ReadOnly && wiFieldEntry.ReadOnlyAttribute.CanOverride == false) {
                    errorLog.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "Field with name {0} and value {1} is readonly and cannot be set",
                        entry.PropertyName,
                        entry.Value ?? string.Empty);
                    errorLog.AppendLine();
                }
            }

            if (errorLog.Length > 0)
                throw new ArgumentException("There is a problem with the field entries passed to create the workitem request: " + errorLog);
        }

        private static object GetDefault(Type type)
        {
            if (type.IsValueType) {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        private static WorkItemFieldEntry GetFieldEntry(PropertyInfo propertyInfo, WorkItem workItem)
        {
            var attr = (JsonPropertyAttribute)propertyInfo
                .GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                .SingleOrDefault();
            if (attr == null)
                return null;

            object value = propertyInfo.GetValue(workItem.Fields);
            if (value == null)
                return null;

            var readonlyAttr = (ReadOnlyAttribute)propertyInfo
                .GetCustomAttributes(typeof(ReadOnlyAttribute), true)
                .SingleOrDefault();
            if (readonlyAttr != null) {
                object defaultValue = GetDefault(propertyInfo.PropertyType);
                if (Equals(defaultValue, value)) {
                    // This is a readonly property with its default value, we just skip it
                    return null;
                }
            }

            string formattedValue;
            if (value is string)
                formattedValue = (string)value;
            else if (value is IFormattable)
                formattedValue = value.ToString();
            else
                return null;

            return new WorkItemFieldEntry {
                ReadOnlyAttribute = readonlyAttr,
                FieldEntry = new FieldEntry {
                    Op = "add",
                    PropertyName = attr.PropertyName,
                    Value = formattedValue
                }
            };
        }

        private class WorkItemFieldEntry
        {
            public ReadOnlyAttribute ReadOnlyAttribute { get; set; }
            public FieldEntry FieldEntry { get; set; }
        }
    }
}