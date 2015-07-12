namespace VsoApi.Contracts.Responses.Git
{
    using System;
    using Newtonsoft.Json;

    public class Project
    {
        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }

        [JsonProperty]
        public string State { get; private set; }
    }
}