

namespace VsoApi.Client.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    [TestClass]
    public class GetFlatWiqlQueryTests
    {
        [TestMethod]
        public void GetFlatWiqlQuery()
        {
            VsoClient client = new VsoClient();
            var request = new WqilFlatRequest {
                RequestBody = new WqilFlatRequest.Body {
                    Query = @"Select [System.Id], [System.Title], [System.State] From WorkItems Where [System.WorkItemType] = 'Task' AND [State] <> 'Closed' AND [State] <> 'Removed' order by [Microsoft.VSTS.Common.Priority] asc, [System.CreatedDate] desc"
                }
            };

            WiqlFlatQueryResponse result = client.WqilResources.Post(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Workitems.Any());
        }
    }
}
