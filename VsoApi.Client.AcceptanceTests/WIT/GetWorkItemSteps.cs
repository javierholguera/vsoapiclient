namespace VsoApi.Client.AcceptanceTests.WIT
{
    using System;
    using System.Globalization;
    using System.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;

    [Binding]
    public class GetWorkItemSteps
    {
        private uint[] _workitemIds;
        private WorkItem _workitemDetails;

        [Given(@"There is a work item with ID (.*)")]
        public void GivenThereIsAWorkItemWithId(uint workItemId)
        {
            _workitemIds = new[] {workItemId};
        }

        [When(@"I get the work item details from the team project")]
        public void WhenIGetTheWorkItemDetailsFromTheTeamProject()
        {
            var client = new VsoClient(Config.BaseUri, Config.Username, Config.Password);
            _workitemDetails = client.WorkItemResources.Get(new WorkItemRequest(_workitemIds.Single()));
        }

        [Then(@"the result is defined")]
        public void ThenTheResultIsDefined()
        {
            Assert.That(_workitemDetails, Is.Not.Null);
        }

        [Then(@"the work item is a task")]
        public void ThenTheWorkItemIsATask()
        {
            Assert.That(_workitemDetails.Fields.SystemWorkItemType, Is.EqualTo("Task"));
        }

        [Then(@"its title is '(.*)'")]
        public void ThenItsTitleIs(string title)
        {
            Assert.That(_workitemDetails.Fields.SystemTitle, Is.EqualTo(title));
        }

        [Then(@"it is assigned to '(.*)'")]
        public void ThenItIsAssignedTo(string assignedTo)
        {
            Assert.That(_workitemDetails.Fields.SystemAssignedTo.StartsWith(assignedTo), Is.True);
        }

        [Then(@"its state is '(.*)'")]
        public void ThenItsStateIs(string state)
        {
            Assert.That(_workitemDetails.Fields.SystemState, Is.EqualTo(state));
        }

        [Then(@"it doesn't contain information about relations")]
        public void ThenItDoesnTContainInformationAboutRelations()
        {
            Assert.That(_workitemDetails.Relations, Is.Empty);
        }

        [When(@"I get the work item details with its relations from the team project")]
        public void WhenIGetTheWorkItemDetailsWithItsRelationsFromTheTeamProject()
        {
            var client = new VsoClient(Config.BaseUri, Config.Username, Config.Password);
            _workitemDetails = client.WorkItemResources.Get(new WorkItemRequest(_workitemIds.Single(), WorkItemExpandType.All));
        }

        [Then(@"the work item contains a list of (.*) relations")]
        public void ThenTheWorkItemContainsAListOfRelations(int relationCount)
        {
            Assert.That(_workitemDetails.Relations.Count(), Is.EqualTo(relationCount));
        }

        [Then(@"I can get information about each work item in the relation")]
        public void ThenICanGetInformationAboutEachWorkItemInTheRelation()
        {
            _workitemDetails.Relations.ToList().ForEach(relation =>
            {
                string[] segments = relation.Url.Segments;
                if (segments.Contains("workitems/", StringComparer.OrdinalIgnoreCase) == false)
                    return;

                uint workItemId = uint.Parse(segments.Last(), CultureInfo.InvariantCulture);

                var client = new VsoClient(Config.BaseUri, Config.Username, Config.Password);
                WorkItem workItemInfo = client.WorkItemResources.Get(new WorkItemRequest(workItemId));
                Assert.IsNotNull(workItemInfo);
                Assert.IsNotNull(workItemInfo.Fields);
            });
        }
    }
}