using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VsoApi.Client.Tests
{
    using VsoApi.Contracts;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            VsoClient client = new VsoClient();
            var request = new GetListOfWorkitems();
            request.Ids.Add("12");
            request.Ids.Add("13");
            request.Ids.Add("14");
            VsoResponse<Workitem> result = client.WorkitemResources.GetAll(request);
            Assert.AreEqual(result.count, 3);
        }
    }
}
