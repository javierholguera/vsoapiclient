namespace VsoApi.Client.Tests.Team
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests.Team;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Team;

    [TestClass]
    public class GetTeams
    {
        [Ignore]
        [TestMethod]
        public void GetListOfTeams()
        {
            var client = new VsoClient(
                new Uri("https://marketinvoice.visualstudio.com/defaultCollection"),
                "javiermi",
                ""); // set this -- typical password with almohadilla

            CollectionResponse<Team> result = client.TeamResources.GetAll(new TeamListRequest("Platform"));

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value.Any());
        }
    }
}