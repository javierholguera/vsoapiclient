namespace VsoApi.Contracts.Models
{
    using System;
    using Newtonsoft.Json;

    public class WorkItemRelationAttribute
    {
        [JsonProperty]
        public string Comment { get; private set; }

        [JsonProperty]
        public bool IsLocked { get; private set; }

        [JsonProperty]
        public DateTime?  AuthorizedDate { get; private set; }

        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public DateTime? ResourceCreatedDate { get; private set; }

        [JsonProperty]
        public DateTime? ResourceModifiedDate { get; private set; }

        [JsonProperty]
        public DateTime? RevisedDate { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }
    }
}