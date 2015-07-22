
namespace VsoApi.Client.Tests.WIT
{
    using System.Collections.Generic;
    using VsoApi.Client.Builders;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Models.WorkItemFieldNames;
    using VsoApi.Contracts.Requests.WIT;
    using Xunit;

    public class CreateWorkItemTests
    {
        [Fact]
        public void CreateTaskWithPlainFieldEntries()
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
            Assert.NotNull(result);
            Assert.Equal("Testing", result.Fields.SystemAreaPath);
            Assert.Equal("Testing", result.Fields.SystemIterationPath);
            Assert.Equal("Created from API Client", result.Fields.SystemTitle);
        }

        [Fact]
        public void CreateBugWithWorkItem()
        {
            var client = new VsoClient();

            var newBug = new WorkItem {
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
                    VstsSeverity = "1 - Critical",
                    VstsReproSteps = "This is what happened!"
                }
            };

            var request = new WorkItemCreateRequestBuilder(client).Create("Testing", newBug);

            WorkItem result = client.WorkItemResources.Patch(request);
            Assert.NotNull(result);
            Assert.Equal("Personal\\Testing", result.Fields.SystemAreaPath);
            Assert.Equal("Personal\\Iteration 1", result.Fields.SystemIterationPath);
            Assert.Equal("This is the bug title", result.Fields.SystemTitle);
        }
    }
}
