
namespace VsoApi.Client.Tests.WIT
{
    using System.Linq;
    using System.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;

    [TestClass]
    public class GetWorkItemTests
    {
        [TestMethod]
        public void GetWorkItemById()
        {
            var client = new VsoClient();
            var request = new WorkItemRequest(91);
            WorkItem result = client.WorkItemResources.Get(request);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void GetWorkItemByNonexistentId()
        {
            var client = new VsoClient();
            var request = new WorkItemRequest(int.MaxValue);
            client.WorkItemResources.Get(request);
        }

        [TestMethod]
        public void GetWorkItemWithLinksAndAttachments()
        {
            var client = new VsoClient();
            var request = new WorkItemRequest(89, WorkItemExpandType.All);
            WorkItem result = client.WorkItemResources.Get(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Relations.Any());
            Assert.IsNotNull(result.Relations.First().Attributes);
            Assert.IsNotNull(result.Links);
        }
    }
}
