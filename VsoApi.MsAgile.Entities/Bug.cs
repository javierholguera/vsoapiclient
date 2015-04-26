namespace VsoApi.MsAgile.Entities
{
    using System;

    public class Bug : BaseWorkItemEntity
    {
        public override WorkItemTypes WorkItemType
        {
            get { return WorkItemTypes.Bug; }
        }

        public string FoundInBuild { get; set; }
        public string Severity { get; set; }
        public string ReproductionSteps { get; set; }
        public string SystemInfo { get; set; }

        public string ResolvedBy { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public string ResolvedReason { get; set; }
        public decimal? StoryPoints { get; set; }

        public string Activity { get; set; }
        public string Priority { get; set; }
        public decimal? CompletedWork { get; set; }
        public decimal? OriginalEstimate { get; set; }
        public decimal? RemainingWork { get; set; }
    }
}