namespace VsoApi.Contracts.Responses
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;

    public class CollectionResponse<T> where T : VsoEntity
    {
        public CollectionResponse()
        {
            Count = 0;
            Value = Enumerable.Empty<T>();
        }

        [JsonProperty]
        public int Count { get; private set; }

        [JsonProperty]
        public IEnumerable<T> Value { get; private set; }
    }
}