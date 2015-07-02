namespace VsoApi.Contracts.Responses.WIT
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;

    public class ClassificationNodeResponse
    {
        public ClassificationNodeResponse()
        {
            Children = new Collection<ClassificationNodeResponse>();
        }

        [JsonProperty]
        public uint Id { get; private set; }

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

        [JsonProperty]
        public ClassificationNodeResponseAttribute Attributes { get; private set; }
    }
    
    public class ClassificationNodeResponseAttribute
    {
        [JsonProperty]
        public DateTimeOffset StartDate { get; private set; }

        [JsonProperty]
        public DateTimeOffset FinishDate { get; private set; }
    }
}