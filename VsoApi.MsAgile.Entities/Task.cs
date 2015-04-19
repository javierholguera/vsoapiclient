namespace VsoApi.MsAgile.Entities
{
    using System;

    public class Task : BaseEntity
    {
        public string Activity { get; set; }
        public string Priority { get; set; }
        public decimal? CompletedWork { get; set; }
        public decimal? OriginalEstimate { get; set; }
        public decimal? RemainingWork { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime? StartDate { get; set; }

        public override WorkItemTypes WorkItemType
        {
            get { return WorkItemTypes.Task; }
        }
    }
}