namespace VsoApi.Contracts.Responses
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;

    public class WorkItemFieldInfo : VsoEntity
    {
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string ReferenceName { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }

        [JsonProperty]
        public bool ReadOnly { get; private set; }

        [JsonProperty]
        public IEnumerable<SupportedOperation> SupportedOperations { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }

    public class SupportedOperation
    {
        [JsonProperty]
        public string ReferenceName { get;private  set; }

        [JsonProperty]
        public string Name { get; private set; }
    }
}