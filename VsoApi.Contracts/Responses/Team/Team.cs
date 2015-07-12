namespace VsoApi.Contracts.Responses.Team
{
    using System;
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;

    public class Team : VsoEntity
    {
        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public Uri IdentityUrl { get; private set; }
    }
}