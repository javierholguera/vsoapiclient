

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

        [TestMethod]
        public void CreateBug()
        {
            var client = new VsoClient();

            var newBug = new WorkItem();
            newBug.Fields.SystemAreaId = 124636; // area id for testing
            newBug.Fields.SystemAreaPath = "Personal\\Testing";
            newBug.Fields.SystemAssignedTo = "Javier Holguera <jholguerablanco@hotmail.com>";
            newBug.Fields.SystemDescription = "This is a bug description";
            newBug.Fields.SystemIterationPath = "Personal\\Iteration 1";
            newBug.Fields.SystemState = "New";
            newBug.Fields.SystemTags = "tag1; tag2";
            newBug.Fields.SystemTeamProject = "Personal";
            newBug.Fields.SystemTitle = "This is the bug title";
            newBug.Fields.SystemWorkItemType = "Bug";
            newBug.Fields.VstsPriority = "1";
            newBug.Fields.VstsSeverity = "4";

            var request = new WorkItemCreateRequest(
                "Testing",
                newBug);

            WorkItem result = client.WorkItemResources.Patch(request);
            Assert.IsNotNull(result);
            Assert.AreEqual("Personal\\Testing", result.Fields.SystemAreaPath);
            Assert.AreEqual("Personal\\Iteration 1", result.Fields.SystemIterationPath);
            Assert.AreEqual("This is the bug title", result.Fields.SystemTitle);
        }
    }
}
