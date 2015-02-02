
namespace VsoApi.Contracts.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Newtonsoft.Json;

    public class WorkItem : VsoEntity
    {
        public WorkItem()
        {
            Relations = new Collection<WorkItemRelation>();
        }

        public int Id { get; set; }
        public int Rev { get; set; }
        public WorkItemFields Fields { get; set; }
        public string Url { get; set; }
        public IEnumerable<WorkItemRelation> Relations { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public Links Links { get; set; }
    }

    public class Links
    {
        public Address Self { get; set; }
        public Address WorkItemUpdates { get; set; }
        public Address WorkItemRevisions { get; set; }
        public Address WorkItemHistory { get; set; }
        public Address Html { get; set; }
        public Address WorkItemType { get; set; }
        public Address Fields { get; set; }
    }

    public class Address
    {
        public string Href { get; set; }
    }

    public class WorkItemRelation
    {
        public string Rel { get; set; }
        public string Url { get; set; }
        public WorkItemRelationAttribute Attributes { get; set; }
    }

    public class WorkItemRelationAttribute
    {
        public string Comment { get; set; }
        public bool IsLocked { get; set; }
        public DateTime?  AuthorizedDate { get; set; }
        public int Id { get; set; }
        public DateTime? ResourceCreatedDate { get; set; }
        public DateTime? ResourceModifiedDate { get; set; }
        public DateTime? RevisedDate { get; set; }
        public string Name { get; set; }
    }
}
