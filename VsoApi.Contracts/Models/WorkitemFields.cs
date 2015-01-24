namespace VsoApi.Contracts.Models
{
    using Newtonsoft.Json;

    public class WorkitemFields
    {
        public const string AreaPathField = "System.AreaPath";
        public const string TeamProjectField = "System.TeamProject";
        public const string IterationPathField = "System.IterationPath";
        public const string WorkitemTypeField = "System.WorkItemType";
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

        [JsonProperty(PropertyName = WorkitemTypeField)]
        public string WorkitemType { get; set; }

        [JsonProperty(PropertyName = StateField)]
        public string State { get; set; }

        [JsonProperty(PropertyName = ReasonField)]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = CreatedDateField)]
        public string CreatedDate { get; set; }

        [JsonProperty(PropertyName = "System.CreatedBy")]
        public string SystemCreatedBy { get; set; }

        [JsonProperty(PropertyName = "System.ChangedDate")]
        public string SystemChangedDate { get; set; }

        [JsonProperty(PropertyName = "System.ChangedBy")]
        public string SystemChangedBy { get; set; }

        [JsonProperty(PropertyName = TitleField)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.Effort")]
        public int MicrosoftVSTSSchedulingEffort { get; set; }

        [JsonProperty(PropertyName = "Kanban.Column")]
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