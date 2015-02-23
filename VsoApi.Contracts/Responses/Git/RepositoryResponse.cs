
namespace VsoApi.Contracts.Responses.Git
{
    using System;
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;

    public class RepositoryResponse : VsoEntity
    {
        [JsonProperty]
        public RepositoryEntry Repository { get; private set; }

        [JsonProperty]
        public int PullRequestId { get; private set; }

        [JsonProperty]
        public string Status { get; private set; }

        [JsonProperty]
        public User CreatedBy { get; private set; }

        [JsonProperty]
        public DateTime CreationDate { get; private set; }

        [JsonProperty]
        public string Title { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public string SourceRefName { get; private set; }

        [JsonProperty]
        public string TargetRefName { get; private set; }

        [JsonProperty]
        public string MergeStatus { get; private set; }

        [JsonProperty]
        public string MergeId { get; private set; }

        [JsonProperty]
        public Commit LastMergeSourceCommit { get; private set; }

        [JsonProperty]
        public Commit LastMergeTargetCommit { get; private set; }

        [JsonProperty]
        public Commit LastMergeCommit { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }
}
