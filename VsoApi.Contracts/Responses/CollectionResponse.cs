using System.Collections.Generic;
using VsoApi.Contracts.Models;

namespace VsoApi.Contracts.Responses
{
    using Newtonsoft.Json;

    public class CollectionResponse<T> where T : VsoEntity
    {
        [JsonProperty]
        public int Count { get; private set; }

        [JsonProperty]
        public IEnumerable<T> Value { get; private set; }
    }
}
