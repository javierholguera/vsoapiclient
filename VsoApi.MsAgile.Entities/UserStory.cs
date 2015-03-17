namespace VsoApi.MsAgile.Entities
{
    using System;

    public class UserStory : BaseEntity
    {
        public string Risk { get; set; }
        public string ResolvedBy { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public string ResolvedReason { get; set; }
        public decimal? StoryPoints { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime? StartDate { get; set; }
    }
}