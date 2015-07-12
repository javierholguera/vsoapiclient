namespace VsoApi.Contracts.Models.WorkItemFieldNames
{
    using System;
    using Newtonsoft.Json;

    public partial class WorkItemFields
    {
        public const string System_AreaId = "System.AreaId";
        public const string System_AreaPath = "System.AreaPath";
        public const string System_AssignedTo = "System.AssignedTo";
        public const string System_AttachedFileCount = "System.AttachedFileCount";
        public const string System_AuthorizedAs = "System.AuthorizedAs";
        public const string System_AuthorizedDate = "System.AuthorizedDate";
        public const string System_BISLinks = "System.BISLinks";
        public const string System_ChangedBy = "System.ChangedBy";
        public const string System_ChangedDate = "System.ChangedDate";
        public const string System_CreatedBy = "System.CreatedBy";
        public const string System_CreatedDate = "System.CreatedDate";
        public const string System_Description = "System.Description";
        public const string System_ExternalLinkCount = "System.ExternalLinkCount";
        public const string System_History = "System.History";
        public const string System_Id = "System.Id";
        public const string System_IterationId = "System.IterationId";
        public const string System_IterationPath = "System.IterationPath";
        public const string System_NodeName = "System.NodeName";
        public const string System_Reason = "System.Reason";
        public const string System_RelatedLinkCount = "System.RelatedLinkCount";
        public const string System_Rev = "System.Rev";
        public const string System_RevisedDate = "System.RevisedDate";
        public const string System_State = "System.State";
        public const string System_Tags = "System.Tags";
        public const string System_TeamProject = "System.TeamProject";
        public const string System_Title = "System.Title";
        public const string System_Watermark = "System.Watermark";
        public const string System_WorkItemType = "System.WorkItemType";

        public WorkItemFields()
        {
            SystemCreatedDate = DateTime.Now;
        }

        [JsonProperty(PropertyName = System_AreaId)]
        public int SystemAreaId { get; set; }

        [JsonProperty(PropertyName = System_AreaPath)]
        public string SystemAreaPath { get; set; }

        [JsonProperty(PropertyName = System_AssignedTo)]
        public string SystemAssignedTo { get; set; }

        [JsonProperty(PropertyName = System_AttachedFileCount)]
        public int SystemAttachedFileCount { get; set; }

        [JsonProperty(PropertyName = System_AuthorizedAs)]
        public string SystemAuthorizedAs { get; set; }

        [JsonProperty(PropertyName = System_AuthorizedDate)]
        public DateTime? SystemAuthorizedDate { get; set; }

        [JsonProperty(PropertyName = System_BISLinks)]
        public string SystemBisLinks { get; set; }

        [JsonProperty(PropertyName = System_ChangedBy)]
        public string SystemChangedBy { get; set; }

        [JsonProperty(PropertyName = System_ChangedDate)]
        public DateTime? SystemChangedDate { get; set; }

        [JsonProperty(PropertyName = System_CreatedBy)]
        public string SystemCreatedBy { get; set; }

        [JsonProperty(PropertyName = System_CreatedDate)]
        public DateTime SystemCreatedDate { get; set; }

        [JsonProperty(PropertyName = System_Description)]
        public string SystemDescription { get; set; }

        [JsonProperty(PropertyName = System_ExternalLinkCount)]
        public int SystemExternalLinkCount { get; set; }

        [JsonProperty(PropertyName = System_History)]
        public string SystemHistory { get; set; }

        [JsonProperty(PropertyName = System_Id)]
        public string SystemId { get; set; }

        [JsonProperty(PropertyName = System_IterationId)]
        public string SystemIterationId { get; set; }

        [JsonProperty(PropertyName = System_IterationPath)]
        public string SystemIterationPath { get; set; }

        [JsonProperty(PropertyName = System_NodeName)]
        public string SystemNodeName { get; set; }

        [JsonProperty(PropertyName = System_Reason)]
        public string SystemReason { get; set; }

        [JsonProperty(PropertyName = System_RelatedLinkCount)]
        public int SystemRelatedLinkCount { get; set; }

        [JsonProperty(PropertyName = System_Rev)]
        public string SystemRev { get; set; }

        [JsonProperty(PropertyName = System_RevisedDate)]
        public DateTime? SystemRevisedDate { get; set; }

        [JsonProperty(PropertyName = System_State)]
        public string SystemState { get; set; }

        [JsonProperty(PropertyName = System_Tags)]
        public string SystemTags { get; set; }

        [JsonProperty(PropertyName = System_TeamProject)]
        public string SystemTeamProject { get; set; }

        [JsonProperty(PropertyName = System_Title)]
        public string SystemTitle { get; set; }

        [JsonProperty(PropertyName = System_Watermark)]
        public string SystemWatermark { get; set; }

        [JsonProperty(PropertyName = System_WorkItemType)]
        public string SystemWorkItemType { get; set; }
    }
}