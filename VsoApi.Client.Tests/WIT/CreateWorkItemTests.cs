

namespace VsoApi.Client.Tests.WIT
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Models.WorkItemFieldNames;
    using VsoApi.Contracts.Requests.WIT;

    [TestClass]
    public class CreateWorkItemTests
    {
        [TestMethod]
        public void CreateWorkItemWithMinimumParameters()
        {
            var client = new VsoClient();
            var request = new WorkItemCreateRequest(
                "Testing",
                "Task",
                new List<FieldEntry> {
                    new FieldEntry { Op = "add", Path = "/fields/" + WorkItemFields.System_AreaPath, Value = "Testing" },
                    new FieldEntry { Op = "add", Path = "/fields/" + WorkItemFields.System_IterationPath, Value = "Testing" },
                    new FieldEntry { Op = "add", Path = "/fields/" + WorkItemFields.System_Title, Value = "Created from API Client" },
                });

            WorkItem result = client.WorkItemResources.Patch(request);
            Assert.IsNotNull(result);
            Assert.AreEqual("Testing", result.Fields.SystemAreaPath);
            Assert.AreEqual("Testing", result.Fields.SystemIterationPath);
            Assert.AreEqual("Created from API Client", result.Fields.SystemTitle);
        }
    }
}
