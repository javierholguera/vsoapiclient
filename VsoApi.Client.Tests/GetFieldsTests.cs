
namespace VsoApi.Client.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Client.Resources;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    /// <summary>
    /// Summary description for GetFieldsTests
    /// </summary>
    [TestClass]
    public class GetFieldsTests
    {
        [TestMethod]
        public void GetAllFields()
        {
            VsoClient client = new VsoClient();
            EmptyRequest request = new EmptyRequest();
            ListResponse<WorkItemFieldInfo> result = client.FieldResources.GetAll(request);
            Assert.IsTrue(result.Value.Any());
        }

        [TestMethod]
        public void GetField()
        {
            VsoClient client = new VsoClient();

            var request = new FieldListRequest { FieldName = "State" };
            WorkItemFieldInfo result = client.FieldResources.Get(request);
            Assert.IsNotNull(result);
        }
    }
}
