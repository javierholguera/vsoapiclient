using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VsoApi.Client.Builders;
using VsoApi.Contracts.Models;
using VsoApi.Contracts.Models.WorkItemFieldNames;
using VsoApi.Contracts.Requests;
using VsoApi.Contracts.Responses;
using VsoApi.Contracts.Responses.WIT;
using Xunit;

namespace VsoApi.Client.Tests.WIT
{
    public class WorkItemCreateRequestBuilderTests
    {
        [Fact]
        public void ThrowsExceptionIfReadOnlyField()
        {
            var bug = CreateValidBug();
            bug.Fields.SystemCreatedDate = DateTime.Now;

            var client = new VsoClient();
            var builder = new WorkItemCreateRequestBuilder(client);
            try {
                builder.Create("Personal", bug);
                Assert.True(false, "We shouldn't reach this point because an ArgumentException should have been thrown");
            } catch (ArgumentException ex) {
                if (ex.Message.Contains("CreatedDate") == false)
                    Assert.True(false, "The ArgumentException message should indicate that CreatedDate cannot be set");
            }
        }

        [Fact]
        public void AllReadOnlyFieldsShouldBeTaggedWithAttribute()
        {
            var client = new VsoClient();
            List<WorkItemFieldInfo> fieldsInfo = client.FieldResources.GetAll(new EmptyRequest()).Value.ToList();

            var serializableFields = typeof (WorkItemFields)
                .GetProperties()
                .Where(prop => prop.GetCustomAttributes(typeof (JsonPropertyAttribute), true).Any())
                .Select(prop => new {
                    PropertyInfo = prop,
                    VsoName = ((JsonPropertyAttribute)prop.GetCustomAttributes(typeof(JsonPropertyAttribute), true).Single()).PropertyName
                })
                .ToList();

            // for each of this properties we should:
            // 1. have an entry in the fields info
            // 2. have it marked with the readonly attribute, if the field info is that they are readonly
            StringBuilder errorLog = new StringBuilder();
            foreach (var entryInfo in serializableFields) {
                var entry = entryInfo;
                WorkItemFieldInfo fieldInfo = fieldsInfo.Single(info => info.ReferenceName == entry.VsoName);
                if (fieldInfo.ReadOnly) {
                    if (entry.PropertyInfo.GetCustomAttributes(typeof (ReadOnlyAttribute)).Any() == false) {
                        errorLog.AppendFormat("Property with name {0} is not marked as readonly despite being considered that by VSO API", entry.VsoName);
                        errorLog.AppendLine();
                    }
                }
            }

            if (errorLog.Length > 0)
                Assert.True(false, errorLog.ToString());
        }

        private static WorkItem CreateValidBug()
        {
            return new WorkItem {
                Fields = {
                    SystemAreaId = 124636,
                    SystemAreaPath = "Personal\\Testing",
                    SystemAssignedTo = "Javier Holguera <jholguerablanco@hotmail.com>",
                    SystemDescription = "This is a bug description",
                    SystemIterationPath = "Personal\\Iteration 1",
                    SystemState = "New",
                    SystemTags = "tag1; tag2",
                    SystemTeamProject = "Personal",
                    SystemTitle = "This is the bug title",
                    SystemWorkItemType = "Bug",
                    VstsPriority = "1",
                    VstsSeverity = "4"
                }
            };
        }
    }
}