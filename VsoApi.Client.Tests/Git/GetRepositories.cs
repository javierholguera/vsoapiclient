

namespace VsoApi.Client.Tests.Git
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Git;

    [TestClass]
    public class GetRepositories
    {
        [Ignore]
        [TestMethod]
        public void GetListOfRepositories()
        {
            var client = new VsoClient(
                new Uri("https://marketinvoice.visualstudio.com/defaultCollection"),
                "javiermi",
                ""); // set this -- typical password with almohadilla

            CollectionResponse<Repository> result = client.RepositoryResources.Get(new EmptyRequest());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value.Any());
        }
    }
}
