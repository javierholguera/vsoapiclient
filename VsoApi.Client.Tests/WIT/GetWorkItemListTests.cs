﻿
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
            var request = new WorkItemListRequest();
            request.Ids.Add("12");
            request.Ids.Add("13");
            request.Ids.Add("14");
            CollectionResponse<WorkItem> result = client.WorkItemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
        }

        [TestMethod]
        public void GetWorkItemsAsOfMonthAgo()
        {
            var client = new VsoClient();
            var request = new WorkItemListRequest();
            request.Ids.Add("12");
            request.Ids.Add("13");
            request.Ids.Add("14");
            request.Fields.Add("System.Title");
            request.Fields.Add("System.CreatedDate");
            request.Fields.Add("System.State");
            request.AsOf = DateTime.Now.AddMonths(-1);

            CollectionResponse<WorkItem> result = client.WorkItemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
        }


        [TestMethod]
        public void GetWorkItemsByIdsWithRelationships()
        {
            var client = new VsoClient();
            var request = new WorkItemListRequest {
                Expand = WorkItemExpandRequest.All
            };
            request.Ids.Add("12");
            request.Ids.Add("13");
            request.Ids.Add("14");
            CollectionResponse<WorkItem> result = client.WorkItemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
            Assert.IsTrue(result.Value.All(workItem => workItem.Links != null));
            Assert.IsTrue(result.Value.All(workItem => workItem.Relations != null));
            Assert.IsTrue(result.Value.Any(workItem => workItem.Relations.Any()));
        }
    }
}