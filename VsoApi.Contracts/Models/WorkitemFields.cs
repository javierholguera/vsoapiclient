namespace VsoApi.Contracts.Models
{
    using Newtonsoft.Json;

    public class WorkItemFields
    {
        public const string KanbanColumnField = "Kanban.Column";
        public const string ChangedByField = "System.ChangedBy";
        public const string EstimatedEffortField = "Microsoft.VSTS.Scheduling.Effort";
        public const string ChangedDateField = "System.ChangedDate";
        public const string CreatedByField = "System.CreatedBy";
        public const string AreaPathField = "System.AreaPath";
        public const string TeamProjectField = "System.TeamProject";
        public const string IterationPathField = "System.IterationPath";
        public const string WorkItemTypeField = "System.WorkItemType";
        public const string StateField = "System.State";
        public const string ReasonField = "System.Reason";
        public const string CreatedDateField = "System.CreatedDate";
        public const string TitleField = "System.Title";

        [JsonProperty(PropertyName = AreaPathField)]
        public string AreaPath { get; set; }

        [JsonProperty(PropertyName = TeamProjectField)]
        public string TeamProject { get; set; }

        [JsonProperty(PropertyName = IterationPathField)]
        public string IterationPath { get; set; }

        [JsonProperty(PropertyName = WorkItemTypeField)]
        public string WorkItemType { get; set; }

        [JsonProperty(PropertyName = StateField)]
        public string State { get; set; }

        [JsonProperty(PropertyName = ReasonField)]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = CreatedDateField)]
        public string CreatedDate { get; set; }

        [JsonProperty(PropertyName = CreatedByField)]
        public string SystemCreatedBy { get; set; }

        [JsonProperty(PropertyName = ChangedDateField)]
        public string SystemChangedDate { get; set; }

        [JsonProperty(PropertyName = ChangedByField)]
        public string SystemChangedBy { get; set; }

        [JsonProperty(PropertyName = TitleField)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = EstimatedEffortField)]
        public int EstimatedEffort { get; set; }

        [JsonProperty(PropertyName = KanbanColumnField)]
        public string KanbanColumn { get; set; }

        [JsonProperty(PropertyName = "System.Description")]
        public string SystemDescription { get; set; }

        [JsonProperty(PropertyName = "System.AssignedTo")]
        public string SystemAssignedTo { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.RemainingWork")]
        public int? MicrosoftVSTSSchedulingRemainingWork { get; set; }

        [JsonProperty(PropertyName = "System.Tags")]
        public string SystemTags { get; set; }
    }
}