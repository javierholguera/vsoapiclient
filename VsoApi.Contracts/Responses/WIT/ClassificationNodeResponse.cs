namespace VsoApi.Contracts.Responses.WIT
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;

    public class ClassificationNodeResponse
    {
        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public ClassificationNodeType StructureType { get; private set; }

        [JsonProperty]
        public bool HasChildren { get; set; }

        [JsonProperty]
        public IEnumerable<ClassificationNodeResponse> Children { get; private set; }

        [JsonProperty(PropertyName = "_links")]
        public Links Links { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }
}