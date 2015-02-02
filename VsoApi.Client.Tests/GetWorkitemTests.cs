
namespace VsoApi.Client.Tests
{
    using System.Globalization;
    using System.Linq;
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

        [TestMethod]
        public void GetWorkitemWithLinksAndAttachments()
        {
            var client = new VsoClient();
            var request = new WorkitemRequest {
                Id = "14",
                Expand = WorkitemExpandRequest.All
            };
            Workitem result = client.WorkitemResources.Get(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Relations.Any());
            Assert.IsNotNull(result.Relations.First().Attributes);
            Assert.IsNotNull(result.Links);
        }
    }
}
