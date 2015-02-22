namespace VsoApi.Contracts.Models
{
    using Newtonsoft.Json;

    public class WorkItemFields
    {
        public const string SystemTagsField = "System.Tags";
        public const string RemainingWorkField = "Microsoft.VSTS.Scheduling.RemainingWork";
        public const string SystemAssignedToField = "System.AssignedTo";
        public const string SystemDescriptionField = "System.Description";
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
        public string AreaPath { get; private set; }

        [JsonProperty(PropertyName = TeamProjectField)]
        public string TeamProject { get; private set; }

        [JsonProperty(PropertyName = IterationPathField)]
        public string IterationPath { get; private set; }

        [JsonProperty(PropertyName = WorkItemTypeField)]
        public string WorkItemType { get; private set; }

        [JsonProperty(PropertyName = StateField)]
        public string State { get; private set; }

        [JsonProperty(PropertyName = ReasonField)]
        public string Reason { get; private set; }

        [JsonProperty(PropertyName = CreatedDateField)]
        public string CreatedDate { get; private set; }

        [JsonProperty(PropertyName = CreatedByField)]
        public string SystemCreatedBy { get; private set; }

        [JsonProperty(PropertyName = ChangedDateField)]
        public string SystemChangedDate { get; private set; }

        [JsonProperty(PropertyName = ChangedByField)]
        public string SystemChangedBy { get; private set; }

        [JsonProperty(PropertyName = TitleField)]
        public string Title { get; private set; }

        [JsonProperty(PropertyName = EstimatedEffortField)]
        public int EstimatedEffort { get; private set; }

        [JsonProperty(PropertyName = KanbanColumnField)]
        public string KanbanColumn { get; private set; }

        [JsonProperty(PropertyName = SystemDescriptionField)]
        public string SystemDescription { get; private set; }

        [JsonProperty(PropertyName = SystemAssignedToField)]
        public string SystemAssignedTo { get; private set; }

        [JsonProperty(PropertyName = RemainingWorkField)]
        public int? MicrosoftVstsSchedulingRemainingWork { get; private set; }

        [JsonProperty(PropertyName = SystemTagsField)]
        public string SystemTags { get; private set; }
    }
}