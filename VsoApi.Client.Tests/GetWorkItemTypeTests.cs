
namespace VsoApi.Client.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    [TestClass]
    public class GetWorkItemTypeTests
    {
        [TestMethod]
        public void GetAllWorkItemTypes()
        {
            var client = new VsoClient();
            CollectionResponse<WorkItemType> result = client.WorkItemTypeResources.GetAll(new WorkItemTypeListRequest {
                Project = "TopReformas"
            });
            Assert.IsTrue(result.Count > 0);
        }


        [TestMethod]
        public void GetWorkItemType()
        {
            var client = new VsoClient();
            WorkItemType result = client.WorkItemTypeResources.Get(new WorkItemTypeRequest {
                Project = "TopReformas",
                Name = "Bug"
            });
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.FieldInstances.Any());
            Assert.IsTrue(result.Transitions != null);
        }
    }
}
