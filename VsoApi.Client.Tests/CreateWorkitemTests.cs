

namespace VsoApi.Client.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using Field = VsoApi.Contracts.Requests.FieldEntry;

    [TestClass]
    public class CreateWorkItemTests
    {
        [TestMethod]
        public void CreateWorkItemWithMinimumParameters()
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
        }
    }
}
