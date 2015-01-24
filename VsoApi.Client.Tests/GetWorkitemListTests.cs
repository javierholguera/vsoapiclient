
namespace VsoApi.Client.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    [TestClass]
    public class GetWorkitemListTests
    {
        [TestMethod]
        public void GetWorkitemsByIdsOnly()
        {
            VsoClient client = new VsoClient();
            var request = new WorkitemListRequest();
            request.Ids.Add("12");
            request.Ids.Add("13");
            request.Ids.Add("14");
            ListResponse<Workitem> result = client.WorkitemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
        }

        [TestMethod]
        public void GetWorkitemsAsOfMonthAgo()
        {
            VsoClient client = new VsoClient();
            var request = new WorkitemListRequest();
            request.Ids.Add("12");
            request.Ids.Add("13");
            request.Ids.Add("14");
            request.Fields.Add("System.Title");
            request.Fields.Add("System.CreatedDate");
            request.Fields.Add("System.State");
            request.AsOf = DateTime.Now.AddMonths(-1);

            ListResponse<Workitem> result = client.WorkitemResources.GetAll(request);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Value.Any());
        }
    }
}
