
namespace VsoApi.Client.Tests
{
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;

    [TestClass]
    public class GetWorkitemTests
    {
        [TestMethod]
        public void GetWorkitemById()
        {
            var client = new VsoClient();
            var request = new WorkitemRequest { Id = "14" };
            Workitem result = client.WorkitemResources.Get(request);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetWorkitemByNonexistentId()
        {
            var client = new VsoClient();
            var request = new WorkitemRequest { Id = int.MaxValue.ToString(CultureInfo.InvariantCulture) };
            Workitem result = client.WorkitemResources.Get(request);
            Assert.IsNotNull(result);
        }
    }
}
