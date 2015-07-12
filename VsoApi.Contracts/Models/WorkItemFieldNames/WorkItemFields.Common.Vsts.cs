namespace VsoApi.Contracts.Models.WorkItemFieldNames
{
    using System;
    using Newtonsoft.Json;

    public partial class WorkItemFields
    {
        public const string Microsoft_Vsts_Build_IntegrationBuild = "Microsoft.VSTS.Build.IntegrationBuild";
        public const string Microsoft_Vsts_Common_ActivatedBy = "Microsoft.VSTS.Common.ActivatedBy";
        public const string Microsoft_Vsts_Common_ActivatedDate = "Microsoft.VSTS.Common.ActivatedDate";
        public const string Microsoft_Vsts_Common_ClosedBy = "Microsoft.VSTS.Common.ClosedBy";
        public const string Microsoft_Vsts_Common_ClosedDate = "Microsoft.VSTS.Common.ClosedDate";
        public const string Microsoft_Vsts_Common_StackRank = "Microsoft.VSTS.Common.StackRank";
        public const string Microsoft_Vsts_Common_StateChangeDate = "Microsoft.VSTS.Common.StateChangeDate";

        [JsonProperty(PropertyName = Microsoft_Vsts_Build_IntegrationBuild)]
        public string VstsIntegrationBuild { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_ActivatedBy)]
        public string VstsActivatedBy { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_ActivatedDate)]
        public DateTime? VstsActivatedDate { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_ClosedBy)]
        public string VstsClosedBy { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_ClosedDate)]
        public DateTime? VstsClosedDate { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_StackRank)]
        public string VstsStackRank { get; set; }

        [JsonProperty(PropertyName = Microsoft_Vsts_Common_StateChangeDate)]
        public DateTime? VstsStateChangeDate { get; set; }
    }
}