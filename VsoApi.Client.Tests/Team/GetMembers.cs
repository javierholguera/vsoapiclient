namespace VsoApi.Client.Tests.Team
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests.Team;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Team;

    [TestClass]
    public class GetMembers
    {
        [Ignore]
        [TestMethod]
        public void GetListOfMembers()
        {
            var client = new VsoClient(
                new Uri("https://marketinvoice.visualstudio.com/defaultCollection"),
                "javiermi",
                ""); // set this -- typical password with almohadilla

            CollectionResponse<Member> result = client.MemberResources.GetAll(new TeamMembersRequest("Platform", "Sprint Team"));

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value.Any());
        }
    }
}