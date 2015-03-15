namespace VsoApi.Client.Tests.WIT
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses.WIT;

    [TestClass]
    public class GetStoredWorkItemsQuery
    {
        [Ignore]
        [TestMethod]
        public void GetStoredWorkItemsQueryOk()
        {
            //var client = new VsoClient();
            //Guid queryId = new Guid("1971215b-dbf8-4b08-b30f-7c4b88ec4de8"); // Personal query - All Workitems Any State

            var client = new VsoClient(
                new Uri("https://marketinvoice.visualstudio.com/defaultCollection"),
                "javiermi",
                ""); // set this -- typical password with almohadilla

            Guid queryId = new Guid("ef88759e-87a5-4ee4-aa76-0e22e9de76fd");

            StoredWiqlRequest request = new StoredWiqlRequest(queryId);
            WiqlQueryResponse result = client.WiqlResources.Post(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.WorkItems.Any());
            Assert.IsNull(result.WorkItemRelations);
            Assert.IsTrue(result.WorkItems.All(wi => wi.Id > 0));
            Assert.IsTrue(result.WorkItems.All(wi => wi.Url != null));
        }
    }
}