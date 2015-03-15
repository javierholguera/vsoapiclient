namespace VsoApi.Client.AcceptanceTests.WIT
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;

    [Binding]
    public class GetWorkitemsSteps
    {
        private ICollection<uint> _workitemIds;
        private CollectionResponse<WorkItem> _allWorkitems;

        [Given(@"There are work items with IDs (.*), (.*) and (.*)")]
        public void GivenThereAreWorkItemsWithIDs(uint firstWorkItem, uint secondWorkItem, uint thirdWorkItem)
        {
            _workitemIds = new[] { firstWorkItem, secondWorkItem, thirdWorkItem };
        }

        [When(@"I get these work items from the team project")]
        public void WhenIGetAllAvailableWorkItemsInTheTeamProject()
        {
            var client = new VsoClient(Config.BaseUri, Config.Username, Config.Password);
            _allWorkitems = client.WorkItemResources.GetAll(new WorkItemListRequest(_workitemIds.ToArray()));
        }

        [Then(@"the result contains (.*) work items")]
        public void ThenTheResultContainsWorkItems(int expectedWorkitemCount)
        {
            Assert.AreEqual(_allWorkitems.Count, expectedWorkitemCount);
            Assert.AreEqual(_allWorkitems.Value.Count(), expectedWorkitemCount);
        }
    }
}