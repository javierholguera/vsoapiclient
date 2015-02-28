namespace VsoApi.Client.AcceptanceTests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;

    [Binding]
    public class WorkitemsSteps
    {
        private ICollection<int> _workitemIds;
        private CollectionResponse<WorkItem> _allWorkitems;

        [Given(@"There are work items with IDs (.*), (.*) and (.*)")]
        public void GivenThereAreWorkItemsWithIDsAnd(int firstWorkItem, int secondWorkItem, int thirdWorkItem)
        {
            _workitemIds = new[] { firstWorkItem, secondWorkItem, thirdWorkItem };
        }

        [When(@"I get all available work items in the team project")]
        public void WhenIGetAllAvailableWorkItemsInTheTeamProject()
        {
            var client = new VsoClient(Config.BaseUri, Config.Username, Config.Password);
            _allWorkitems = client.WorkItemResources.GetAll(
                new WorkItemListRequest(_workitemIds.Select(id => id.ToString(CultureInfo.InvariantCulture)).ToArray()));
        }

        [Then(@"the result contains (.*) work items")]
        public void ThenTheResultContainsWorkItems(int expectedWorkitemCount)
        {
            Assert.AreEqual(_allWorkitems.Count, expectedWorkitemCount);
            Assert.AreEqual(_allWorkitems.Value.Count(), expectedWorkitemCount);
        }
    }
}