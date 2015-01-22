using System.Collections.Generic;

namespace VsoApi.Contracts
{
    using System.Collections.Specialized;
    using RestSharp.Deserializers;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Responses;

    public class Fields
    {
        [DeserializeAs(Name = "System.AreaPath")]
        public string SystemAreaPath { get; set; }

        [DeserializeAs(Name = "System.TeamProject")]
        public string SystemTeamProject { get; set; }

        [DeserializeAs(Name = "System.IterationPath")]
        public string SystemIterationPath { get; set; }

        [DeserializeAs(Name = "System.WorkItemType")]
        public string SystemWorkItemType { get; set; }

        [DeserializeAs(Name = "System.State")]
        public string SystemState { get; set; }

        [DeserializeAs(Name = "System.Reason")]
        public string SystemReason { get; set; }

        [DeserializeAs(Name = "System.CreatedDate")]
        public string SystemCreatedDate { get; set; }

        [DeserializeAs(Name = "System.CreatedBy")]
        public string SystemCreatedBy { get; set; }

        [DeserializeAs(Name = "System.ChangedDate")]
        public string SystemChangedDate { get; set; }

        [DeserializeAs(Name = "System.ChangedBy")]
        public string SystemChangedBy { get; set; }

        [DeserializeAs(Name = "System.Title")]
        public string SystemTitle { get; set; }

        [DeserializeAs(Name = "Microsoft.VSTS.Scheduling.Effort")]
        public int MicrosoftVSTSSchedulingEffort { get; set; }

        [DeserializeAs(Name = "Kanban.Column")]
        public string KanbanColumn { get; set; }

        [DeserializeAs(Name = "System.Description")]
        public string SystemDescription { get; set; }

        [DeserializeAs(Name = "System.AssignedTo")]
        public string SystemAssignedTo { get; set; }

        [DeserializeAs(Name = "Microsoft.VSTS.Scheduling.RemainingWork")]
        public int? MicrosoftVSTSSchedulingRemainingWork { get; set; }

        [DeserializeAs(Name = "System.Tags")]
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
