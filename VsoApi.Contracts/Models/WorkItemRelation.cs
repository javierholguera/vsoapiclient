namespace VsoApi.Contracts.Models
{
    using System;
    using Newtonsoft.Json;

    public class WorkItemRelation
    {
        [JsonProperty]
        public string Rel { get; set; }

        [JsonProperty]
        public Uri Url { get; set; }

        [JsonProperty]
        public WorkItemRelationAttribute Attributes { get; set; }
    }
}