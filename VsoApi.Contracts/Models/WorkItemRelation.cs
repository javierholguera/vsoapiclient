namespace VsoApi.Contracts.Models
{
    using System;
    using Newtonsoft.Json;

    public class WorkItemRelation
    {
        [JsonProperty]
        public string Rel { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }

        [JsonProperty]
        public WorkItemRelationAttribute Attributes { get; private set; }
    }
}