
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

        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public int Rev { get; private set; }

        [JsonProperty]
        public WorkItemFields Fields { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }

        [JsonProperty]
        public IEnumerable<WorkItemRelation> Relations { get; private set; }

        [JsonProperty(PropertyName = "_links")]
        public Links Links { get; private set; }
    }
}
