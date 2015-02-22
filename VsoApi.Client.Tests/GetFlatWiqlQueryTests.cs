

namespace VsoApi.Client.Tests
{
    using System;
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
            var request = new WiqlFlatRequest {
                RequestBody = new Body {
                    Query = @"Select [System.Id], [System.Title], [System.State] From WorkItems Where [System.WorkItemType] = 'Task' AND [State] <> 'Closed' AND [State] <> 'Removed' order by [Microsoft.VSTS.Common.Priority] asc, [System.CreatedDate] desc"
                }
            };

            WiqlFlatQueryResponse result = client.WiqlResources.Post(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.WorkItems.Any());
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.WorkItems.First().Id));
            Assert.IsNotNull(result.WorkItems.First().Url);
        }
    }
}
