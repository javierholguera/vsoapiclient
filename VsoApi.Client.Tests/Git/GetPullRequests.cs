
namespace VsoApi.Client.Tests.Git
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests.Git;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Git;

    [TestClass]
    public class GetPullRequests
    {
        [TestMethod]
        public void GetListOfPullRequests()
        {
            var client = new VsoClient(
                new Uri("https://marketinvoice.visualstudio.com/defaultCollection"),
                "javiermi",
                ""); // set this

            // Id for the platform repository 
            CollectionResponse<RepositoryResponse> result = client.PullRequestResources.Get(
                new PullRequestListRequest("ba91c08c-cbcc-4d55-83fe-0da8e63bc9e1", PullRequestStatus.Completed));

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value.Any());
        }
    }
}
