
namespace VsoApi.Client.Tests.WIT
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.WIT;

    [TestClass]
    public class GetFieldsTests
    {
        [TestMethod]
        public void GetAllFields()
        {
            var client = new VsoClient();
            var request = new EmptyRequest();
            CollectionResponse<WorkItemFieldInfo> result = client.FieldResources.GetAll(request);
            Assert.IsTrue(result.Value.Any());
        }

        [TestMethod]
        public void GetField()
        {
            var client = new VsoClient();

            var request = new FieldListRequest("State");
            WorkItemFieldInfo result = client.FieldResources.Get(request);
            Assert.IsNotNull(result);
        }
    }
}
