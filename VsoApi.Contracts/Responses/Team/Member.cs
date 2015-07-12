namespace VsoApi.Contracts.Responses.Team
{
    using System;
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;

    public class Member : VsoEntity
    {
        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public string DisplayName { get; private set; }

        [JsonProperty]
        public string UniqueName { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
        
        [JsonProperty]
        public Uri ImageUrl { get; private set; }

        [JsonProperty]
        public bool IsContainer { get; private set; }
    }
}