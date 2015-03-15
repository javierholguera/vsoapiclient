

namespace VsoApi.Client.Tests.WIT
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses.WIT;

    [TestClass]
    public class WiqlQueriesTests
    {
        [TestMethod]
        public void GetFlatWiqlQuery()
        {
            var client = new VsoClient();
            var request = new WiqlRequest(
@"Select [System.Id], [System.Title], [System.State] 
From WorkItems 
Where [System.WorkItemType] = 'Task' 
	AND [State] <> 'Closed' 
	AND [State] <> 'Removed' 
	order by [Microsoft.VSTS.Common.Priority] asc, [System.CreatedDate] desc");

            WiqlQueryResponse result = client.WiqlResources.Post(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.WorkItems.Any());
            Assert.AreNotEqual(0, result.WorkItems.First().Id);
            Assert.IsNotNull(result.WorkItems.First().Url);
            Assert.IsNull(result.WorkItemRelations);
        }

        [TestMethod]
        public void GetOneHopQuery()
        {
            var client = new VsoClient();
            var request = new WiqlRequest("Personal",
@"SELECT [System.Id], [System.Links.LinkType], [System.WorkItemType], [System.Title], [System.State] 
FROM WorkItemLinks 
WHERE ([Source].[System.TeamProject] = @project 
	AND  [Source].[System.State] <> 'Done') 
	AND ([System.Links.LinkType] <> '') 
	And ([Target].[System.State] <> 'Removed' 
	AND [Target].[System.WorkItemType] NOT IN GROUP 'Microsoft.FeatureCategory') mode(MustContain)");

            WiqlQueryResponse result = client.WiqlResources.Post(request);
            Assert.IsNotNull(result);
            Assert.IsNull(result.WorkItems);
            Assert.IsTrue(result.WorkItemRelations.Any());

            var relation = result.WorkItemRelations.First();
            Assert.IsNotNull(relation.Target);
            Assert.AreNotEqual(0, relation.Target.Id);
            Assert.IsNotNull(relation.Target.Url);
        }

        [TestMethod]
        public void GetTreeQuery()
        {
            var client = new VsoClient();
            var request = new WiqlRequest("Personal",
@"Select [System.Id], [System.WorkItemType], [System.Title], [System.AssignedTo], [System.State] 
From WorkItemLinks 
WHERE (Source.[System.TeamProject] = @project 
	and Source.[System.State] <> 'Removed') 
	and ([System.Links.LinkType] = 'System.LinkTypes.Hierarchy-Forward') 
	and (Target.[System.WorkItemType] <> '') mode(Recursive)");

            WiqlQueryResponse result = client.WiqlResources.Post(request);
            Assert.IsNotNull(result);
            Assert.IsNull(result.WorkItems);
            Assert.IsTrue(result.WorkItemRelations.Any());

            var relation = result.WorkItemRelations.First();
            Assert.IsNotNull(relation.Target);
            Assert.AreNotEqual(0, relation.Target.Id);
            Assert.IsNotNull(relation.Target.Url);
        }
    }
}