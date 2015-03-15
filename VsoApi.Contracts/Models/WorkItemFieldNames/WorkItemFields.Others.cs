namespace VsoApi.Contracts.Models.WorkItemFieldNames
{
    using System;
    using Newtonsoft.Json;

    public partial class WorkItemFields
    {
        // Bugs only
        public const string Microsoft_Vsts_Build_FoundId = "Microsoft.VSTS.Build.FoundIn";
        public const string Microsoft_Vsts_Common_Severity = "Microsoft.VSTS.Common.Severity";
        public const string Microsoft_Vsts_Tcm_ReproSteps = "Microsoft.VSTS.TCM.ReproSteps";
        public const string Microsoft_Vsts_Tcm_SystemInfo = "Microsoft.VSTS.TCM.SystemInfo";

        [JsonProperty(PropertyName = Microsoft_Vsts_Build_FoundId)]
        public string VstsBuildFoundIn { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_Severity)]
        public string VstsSeverity { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Tcm_ReproSteps)]
        public string VstsReproSteps { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Tcm_SystemInfo)]
        public string VstsSystemInfo { get; set; }

        // User Stories only
        public const string Microsoft_Vsts_Common_Risk = "Microsoft.VSTS.Common.Risk";

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_Risk)]
        public string VstsRisk { get; set; }

        // Bugs & User Stories
        public const string Microsoft_Vsts_Common_ResolvedBy = "Microsoft.VSTS.Common.ResolvedBy";
        public const string Microsoft_Vsts_Common_ResolvedDate = "Microsoft.VSTS.Common.ResolvedDate";
        public const string Microsoft_Vsts_Common_ResolvedReason = "Microsoft.VSTS.Common.ResolvedReason";
        public const string Microsoft_Vsts_Scheduling_StoryPoints = "Microsoft.VSTS.Scheduling.StoryPoints";

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_ResolvedBy)]
        public string VstsResolvedBy { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_ResolvedDate)]
        public DateTime? VstsResolvedDate { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_ResolvedReason)]
        public string VstsResolvedReason { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Scheduling_StoryPoints)]
        public decimal? VstsStoryPoints { get; set; }

        // Bugs & Tasks
        public const string Microsoft_Vsts_Common_Activity = "Microsoft.VSTS.Common.Activity";
        public const string Microsoft_Vsts_Common_Priority = "Microsoft.VSTS.Common.Priority";
        public const string Microsoft_Vsts_Scheduling_CompletedWork = "Microsoft.VSTS.Scheduling.CompletedWork";
        public const string Microsoft_Vsts_Scheduling_OriginalEstimate = "Microsoft.VSTS.Scheduling.OriginalEstimate";
        public const string Microsoft_Vsts_Scheduling_RemainingWork = "Microsoft.VSTS.Scheduling.RemainingWork";

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_Activity)]
        public string VstsActivity { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_Priority)]
        public string VstsPriority { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Scheduling_CompletedWork)]
        public decimal? VstsCompletedWork { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Scheduling_OriginalEstimate)]
        public decimal? VstsOriginalEstimate { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Scheduling_RemainingWork)]
        public decimal? VstsRemainingWork { get; set; }

        // User Stories & Tasks
        public const string Microsoft_Vsts_Scheduling_FinishDate = "Microsoft.VSTS.Scheduling.FinishDate";
        public const string Microsoft_Vsts_Scheduling_StartDate = "Microsoft.VSTS.Scheduling.StartDate";

        [JsonProperty(PropertyName = Microsoft_Vsts_Scheduling_FinishDate)]
        public DateTime? VstsFinishDate { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Scheduling_StartDate)]
        public DateTime? VstsStartDate { get; set; }
    }
}