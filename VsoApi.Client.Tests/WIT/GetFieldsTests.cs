
namespace VsoApi.Client.Tests.WIT
{
    using System.Linq;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.WIT;
    using Xunit;

    public class GetFieldsTests
    {
        [Fact]
        public void GetAllFields()
        {
            var client = new VsoClient();
            var request = new EmptyRequest();
            CollectionResponse<WorkItemFieldInfo> result = client.FieldResources.GetAll(request);
            Assert.True(result.Value.Any());
        }

        [Fact]
        public void GetField()
        {
            var client = new VsoClient();

            var request = new FieldListRequest("State");
            WorkItemFieldInfo result = client.FieldResources.Get(request);
            Assert.NotNull(result);
        }
    }
}
