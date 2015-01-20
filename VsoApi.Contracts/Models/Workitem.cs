using System.Collections.Generic;

namespace VsoApi.Contracts
{
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Responses;

    public class Fields
    {
        public string SystemAreaPath { get; set; }
        public string SystemTeamProject { get; set; }
        public string SystemIterationPath { get; set; }
        public string SystemWorkItemType { get; set; }
        public string SystemState { get; set; }
        public string SystemReason { get; set; }
        public string SystemCreatedDate { get; set; }
        public string SystemCreatedBy { get; set; }
        public string SystemChangedDate { get; set; }
        public string SystemChangedBy { get; set; }
        public string SystemTitle { get; set; }
        public int MicrosoftVSTSSchedulingEffort { get; set; }
        public string KanbanColumn { get; set; }
        public string SystemDescription { get; set; }
        public string SystemAssignedTo { get; set; }
        public int? MicrosoftVSTSSchedulingRemainingWork { get; set; }
        public string SystemTags { get; set; }
    }

    public class Workitem : VsoEntity
    {
        public int id { get; set; }
        public int rev { get; set; }
        public Fields fields { get; set; }
        public string url { get; set; }
    }
}
