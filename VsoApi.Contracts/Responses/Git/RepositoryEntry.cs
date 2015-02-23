
namespace VsoApi.Contracts.Responses.Git
{
    using System;
    using Newtonsoft.Json;

    public class RepositoryEntry
    {
        [JsonProperty]
        public string Id { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }
}
