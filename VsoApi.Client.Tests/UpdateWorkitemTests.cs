

namespace VsoApi.Client.Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using Field = VsoApi.Contracts.Requests.WorkItemCreateRequest.FieldEntry;

    [TestClass]
    public class UpdateWorkItemTests
    {
        [TestMethod]
        public void UpdateWorkItem()
        {
            VsoClient client = new VsoClient();
            var request = new WorkItemCreateRequest {
                Project = "TopReformas",
                WorkItemTypeName = "Task",
                Body = new List<Field> {
                    new Field { Op = "add", Path = "/fields/" + WorkItemFields.AreaPathField, Value = "TopReformas" },
                    new Field { Op = "add", Path = "/fields/" + WorkItemFields.IterationPathField, Value = "TopReformas" },
                    new Field { Op = "add", Path = "/fields/" + WorkItemFields.TitleField, Value = "Created from API Client" },
                }
            };

            WorkItem result = client.WorkItemResources.Patch(request);
            Assert.IsNotNull(result);

            int id = result.Id;
            WorkItem createdWorkItem = client.WorkItemResources.Get(
                new WorkItemRequest { Id = id.ToString(CultureInfo.InvariantCulture) });
            Assert.AreEqual(createdWorkItem.Fields.Title, "Created from API Client");

            // Update the workItem
            WorkItemUpdateRequest updateRequest = new WorkItemUpdateRequest {
                Id = id.ToString(CultureInfo.InvariantCulture),
                Body = new List<WorkItemUpdateRequest.FieldEntry> {
                    new WorkItemUpdateRequest.FieldEntry {
                        Op = "replace",
                        Path = "/fields/" + WorkItemFields.TitleField,
                        Value = "Updated title!"
                    }
                }
            };

            WorkItem updateResult = client.WorkItemResources.Patch(updateRequest);

            WorkItem updatedWorkItem = client.WorkItemResources.Get(
                new WorkItemRequest { Id = updateResult.Id.ToString(CultureInfo.InvariantCulture) });
            Assert.AreEqual("Updated title!", updatedWorkItem.Fields.Title);
        }
    }
}
