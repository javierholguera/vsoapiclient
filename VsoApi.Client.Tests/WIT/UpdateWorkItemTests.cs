

namespace VsoApi.Client.Tests.WIT
{
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Models.WorkItemFieldNames;
    using VsoApi.Contracts.Requests.WIT;

    [TestClass]
    public class UpdateWorkItemTests
    {
        [TestMethod]
        public void UpdateWorkItem()
        {
            var client = new VsoClient();
            var request = new WorkItemCreateRequest(
                "Testing",
                "Task",
                new List<FieldEntry> {
                    new FieldEntry { Op = "add", PropertyName = WorkItemFields.System_AreaPath, Value = "Testing" },
                    new FieldEntry { Op = "add", PropertyName = WorkItemFields.System_IterationPath, Value = "Testing" },
                    new FieldEntry { Op = "add", PropertyName = WorkItemFields.System_Title, Value = "Created from API Client" },
                });

            WorkItem result = client.WorkItemResources.Patch(request);
            Assert.IsNotNull(result);

            uint id = result.Id;
            WorkItem createdWorkItem = client.WorkItemResources.Get(new WorkItemRequest(id));
            Assert.AreEqual(createdWorkItem.Fields.SystemTitle, "Created from API Client");

            // Update the workItem
            var updateRequest = new WorkItemUpdateRequest(
                id.ToString(CultureInfo.InvariantCulture),
                new List<FieldEntry> {
                    new FieldEntry {
                        Op = "replace",
                        PropertyName = WorkItemFields.System_Title,
                        Value = "Updated title!"
                    }
                });

            WorkItem updateResult = client.WorkItemResources.Patch(updateRequest);

            WorkItem updatedWorkItem = client.WorkItemResources.Get(new WorkItemRequest(updateResult.Id));
            Assert.AreEqual("Updated title!", updatedWorkItem.Fields.SystemTitle);
        }
    }
}
