namespace VsoApi.Client.Tests.WIT
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Models.WorkItemFieldNames;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;

    [TestClass]
    public class GetWorkItemListTests
    {
        [TestMethod]
        public void GetWorkItemsByIdsOnly()
        {
            var client = new VsoClient();
            var request = new WorkItemListRequest(new uint[] { 89, 114, 115 });
            CollectionResponse<WorkItem> result = client.WorkItemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
        }

        [TestMethod]
        public void GetWorkItemsAsOfMinuteAgo()
        {
            var client = new VsoClient();
            var request = new WorkItemListRequest(
                new uint[] { 89, 114, 115 },
                DateTime.Now.AddMinutes(-1),
                new[] { WorkItemFields.System_Title, WorkItemFields.System_CreatedDate, WorkItemFields.System_State });

            CollectionResponse<WorkItem> result = client.WorkItemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
            result.Value.ToList().ForEach(workItem =>
            {
                Assert.IsFalse(string.IsNullOrEmpty(workItem.Fields.SystemTitle));
                Assert.AreNotEqual(DateTime.MinValue, workItem.Fields.SystemCreatedDate);
                Assert.IsFalse(string.IsNullOrEmpty(workItem.Fields.SystemState));
            });
        }

        [TestMethod]
        public void GetWorkItemsByIdsWithRelationships()
        {
            var client = new VsoClient();
            var request = new WorkItemListRequest(
                new uint[] { 89, 114, 115 },
                null,
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