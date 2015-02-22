namespace VsoApi.Contracts.Models
{
    using Newtonsoft.Json;

    public class Links
    {
        [JsonProperty]
        public Address Self { get; private set; }

        [JsonProperty]
        public Address WorkItemUpdates { get; private set; }

        [JsonProperty]
        public Address WorkItemRevisions { get; private set; }

        [JsonProperty]
        public Address WorkItemHistory { get; private set; }

        [JsonProperty]
        public Address Html { get; private set; }

        [JsonProperty]
        public Address WorkItemType { get; private set; }

        [JsonProperty]
        public Address Fields { get; private set; }
    }
}