namespace VsoApi.Contracts.Responses.WIT
{
    using System;
    using Newtonsoft.Json;

    public class WorkItemField
    {
        [JsonProperty]
        public string ReferenceName { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }
}