

namespace VsoApi.Client.Tests.WIT
{
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;

    [TestClass]
    public class UpdateWorkItemTests
    {
        [TestMethod]
        public void UpdateWorkItem()
        {
            var client = new VsoClient();
            var request = new WorkItemCreateRequest(
                "TopReformas",
                "Task",
                new List<FieldEntry> {
                    new FieldEntry { Op = "add", Path = "/fields/" + WorkItemFields.AreaPathField, Value = "TopReformas" },
                    new FieldEntry { Op = "add", Path = "/fields/" + WorkItemFields.IterationPathField, Value = "TopReformas" },
                    new FieldEntry { Op = "add", Path = "/fields/" + WorkItemFields.TitleField, Value = "Created from API Client" },
                });

            WorkItem result = client.WorkItemResources.Patch(request);
            Assert.IsNotNull(result);

            int id = result.Id;
            WorkItem createdWorkItem = client.WorkItemResources.Get(new WorkItemRequest(id.ToString(CultureInfo.InvariantCulture)));
            Assert.AreEqual(createdWorkItem.Fields.Title, "Created from API Client");

            // Update the workItem
            var updateRequest = new WorkItemUpdateRequest(
                id.ToString(CultureInfo.InvariantCulture),
                new List<FieldEntry> {
                    new FieldEntry {
                        Op = "replace",
                        Path = "/fields/" + WorkItemFields.TitleField,
                        Value = "Updated title!"
                    }
                });

            WorkItem updateResult = client.WorkItemResources.Patch(updateRequest);

            WorkItem updatedWorkItem = client.WorkItemResources.Get(
                new WorkItemRequest(updateResult.Id.ToString(CultureInfo.InvariantCulture)));
            Assert.AreEqual("Updated title!", updatedWorkItem.Fields.Title);
        }
    }
}
