namespace VsoApi.Contracts.Models
{
    using System;
    using Newtonsoft.Json;

    public class ElementIdentity
    {
        [JsonProperty]
        public uint Id { get; set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }
}