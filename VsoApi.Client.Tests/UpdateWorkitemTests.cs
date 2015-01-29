

namespace VsoApi.Client.Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using Field = VsoApi.Contracts.Requests.WorkitemCreateRequest.FieldEntry;

    [TestClass]
    public class UpdateWorkitemTests
    {
        [TestMethod]
        public void UpdateWorkitem()
        {
            VsoClient client = new VsoClient();
            var request = new WorkitemCreateRequest {
                Project = "TopReformas",
                WorkItemTypeName = "Task",
                Body = new List<Field> {
                    new Field { Op = "add", Path = "/fields/" + WorkitemFields.AreaPathField, Value = "TopReformas" },
                    new Field { Op = "add", Path = "/fields/" + WorkitemFields.IterationPathField, Value = "TopReformas" },
                    new Field { Op = "add", Path = "/fields/" + WorkitemFields.TitleField, Value = "Created from API Client" },
                }
            };

            Workitem result = client.WorkitemResources.Patch(request);
            Assert.IsNotNull(result);

            int id = result.Id;
            Workitem createdWorkitem = client.WorkitemResources.Get(
                new WorkitemRequest { Id = id.ToString(CultureInfo.InvariantCulture) });
            Assert.AreEqual(createdWorkitem.Fields.Title, "Created from API Client");

            // Update the workitem
            WorkitemUpdateRequest updateRequest = new WorkitemUpdateRequest {
                Id = id.ToString(CultureInfo.InvariantCulture),
                Body = new List<WorkitemUpdateRequest.FieldEntry> {
                    new WorkitemUpdateRequest.FieldEntry {
                        Op = "replace",
                        Path = "/fields/" + WorkitemFields.TitleField,
                        Value = "Updated title!"
                    }
                }
            };

            Workitem updateResult = client.WorkitemResources.Patch(updateRequest);

            Workitem updatedWorkitem = client.WorkitemResources.Get(
                new WorkitemRequest { Id = updateResult.Id.ToString(CultureInfo.InvariantCulture) });
            Assert.AreEqual("Updated title!", updatedWorkitem.Fields.Title);
        }
    }
}
