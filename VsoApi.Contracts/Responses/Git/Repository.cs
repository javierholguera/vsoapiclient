using System;

namespace VsoApi.Contracts.Responses.Git
{
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;

    public class Repository : VsoEntity
    {
        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }

        [JsonProperty]
        public Project Project { get; private set; }

        [JsonProperty]
        public Uri RemoteUrl { get; private set; }
    }

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
