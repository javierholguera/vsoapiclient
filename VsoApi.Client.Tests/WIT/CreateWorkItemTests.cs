

namespace VsoApi.Client.Tests.WIT
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;

    [TestClass]
    public class CreateWorkItemTests
    {
        [TestMethod]
        public void CreateWorkItemWithMinimumParameters()
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
        }
    }
}
