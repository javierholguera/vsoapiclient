
namespace VsoApi.Contracts.Responses.Git
{
    using System;
    using Newtonsoft.Json;

    public class Commit
    {
        [JsonProperty]
        public string CommitId { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }
}
