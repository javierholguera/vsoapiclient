namespace VsoApi.MsAgile.Entities
{
    using System;
    using System.Collections.Generic;

    public abstract class BaseEntity
    {
        public string Id { get; protected set; }
        public string Project { get; protected set; }
    }

    public abstract class BaseWorkItemEntity : BaseEntity
    {
        /// 
        /// System Fields
        /// 
        
        public int AreaId { get; private set; }
        public string AreaPath { get; private set; }
        public string AssignedTo { get; private set; }
        public int AttachedFileCount { get; private set; }
        public string AuthorizedAs { get; private set; }
        public DateTime? AuthorizedDate { get; private set; }
        public string BisLinks { get; private set; }
        public string ChangedBy { get; private set; }
        public DateTime? ChangedDate { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Description { get; private set; }
        public int ExternalLinkCount { get; private set; }
        public string History { get; private set; }
        public string IterationId { get; private set; }
        public string IterationPath { get; private set; }
        public string NodeName { get; private set; }
        public string Reason { get; private set; }
        public int RelatedLinkCount { get; private set; }
        public string Rev { get; private set; }
        public DateTime? RevisedDate { get; private set; }
        public string State { get; private set; }
        public IEnumerable<string> Tags { get; set; }
        public string Title { get; private set; }
        public string Watermark { get; private set; }
        public abstract WorkItemTypes WorkItemType { get; }

        /// 
        /// VSTS Fields
        /// 

        public string IntegrationBuild { get; private set; }
        public string ActivatedBy { get; private set; }
        public DateTime? ActivatedDate { get; private set; }
        public string ClosedBy { get; private set; }
        public DateTime? ClosedDate { get; private set; }
        public string StackRank { get; private set; }
        public DateTime StateChangeDate { get; private set; }
    }
}