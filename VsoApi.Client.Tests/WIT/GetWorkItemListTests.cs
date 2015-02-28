namespace VsoApi.Client.Tests.WIT
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;

    [TestClass]
    public class GetWorkItemListTests
    {
        [TestMethod]
        public void GetWorkItemsByIdsOnly()
        {
            var client = new VsoClient();
            var request = new WorkItemListRequest(new[] {"12", "13", "14"});
            CollectionResponse<WorkItem> result = client.WorkItemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
        }

        [TestMethod]
        public void GetWorkItemsAsOfMonthAgo()
        {
            var client = new VsoClient();
            var request = new WorkItemListRequest(
                new[] { "12", "13", "14" },
                DateTime.Now.AddMonths(-1),
                new[] { "System.Title", "System.CreatedDate", "System.State" });

            CollectionResponse<WorkItem> result = client.WorkItemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
        }

        [TestMethod]
        public void GetWorkItemsByIdsWithRelationships()
        {
            var client = new VsoClient();
            var request = new WorkItemListRequest(
                new[] { "12", "13", "14" },
                null,
                Enumerable.Empty<string>().ToList(), 
                WorkItemExpandType.All);

            CollectionResponse<WorkItem> result = client.WorkItemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
            Assert.IsTrue(result.Value.All(workItem => workItem.Links != null));
            Assert.IsTrue(result.Value.All(workItem => workItem.Relations != null));
            Assert.IsTrue(result.Value.Any(workItem => workItem.Relations.Any()));
        }
    }
}