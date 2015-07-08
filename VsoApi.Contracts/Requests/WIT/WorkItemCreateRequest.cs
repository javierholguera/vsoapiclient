
namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Models;

    public class WorkItemCreateRequest : VsoRequest
    {
        public WorkItemCreateRequest(string project, string workItemTypeName, IEnumerable<FieldEntry> fieldEntries) : base(project)
        {
            if (workItemTypeName == null)
                throw new ArgumentNullException("workItemTypeName");
            if (fieldEntries == null)
                throw new ArgumentNullException("fieldEntries");

            if (string.IsNullOrWhiteSpace(workItemTypeName))
                throw new ArgumentException("Work Item Type Name is mandatory to create a new work item", "workItemTypeName");

            WorkItemTypeName = workItemTypeName;
            FieldEntries = fieldEntries;
        }

        /// <summary>
        /// Initializes a workitem create request from workitem instance that contains all
        /// the data to be sent to the server.
        /// </summary>
        /// <param name="project">Project.</param>
        /// <param name="workItem">Instance that contains all the necessary info.</param>
        public WorkItemCreateRequest(string project, WorkItem workItem) : base(project)
        {
            if (workItem == null)
                throw new ArgumentNullException("workItem");
            if (workItem.Fields == null)
                throw new ArgumentException("A workitem without fields cannot be created");
            if (string.IsNullOrWhiteSpace(workItem.Fields.SystemWorkItemType))
                throw new ArgumentException("The workItem has to define its type before been created (field SystemWorkItemType)");

            WorkItemTypeName = workItem.Fields.SystemWorkItemType;
            FieldEntries = workItem.Fields
                .GetType()
                .GetProperties()
                .Select(prop => GetFieldEntry(prop, workItem))
                .Where(field => field != null)
                .ToList();
        }

        private string WorkItemTypeName { get; set; }
        private IEnumerable<FieldEntry> FieldEntries { get; set; }

        protected override Method Method
        {
            get { return Method.PATCH; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/${workitemtypename}";
            restRequest.AddUrlSegment("workitemtypename", WorkItemTypeName);

            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            restRequest.AddParameter(
                "application/json-patch+json", JsonConvert.SerializeObject(FieldEntries), ParameterType.RequestBody);
        }

        private FieldEntry GetFieldEntry(PropertyInfo propertyInfo, WorkItem workItem)
        {
            var attr = (JsonPropertyAttribute)propertyInfo
                .GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                .FirstOrDefault();
            if (attr == null)
                return null;

            object value = propertyInfo.GetValue(workItem.Fields);
            if (value == null)
                return null;

            string formattedValue;
            if (value is string)
                formattedValue = (string)value;
            else if (value is IFormattable)
                formattedValue = value.ToString();
            else
                return null;

            return new FieldEntry {
                Op = "add",
                Path = "/fields/" + attr.PropertyName,
                Value = formattedValue
            };
        }
    }
}
