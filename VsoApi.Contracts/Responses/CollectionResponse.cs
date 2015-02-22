using System.Collections.Generic;
using VsoApi.Contracts.Models;

namespace VsoApi.Contracts.Responses
{
    public class CollectionResponse<T> where T : VsoEntity
    {
        public int Count { get; set; }
        public IEnumerable<T> Value { get; set; }
    }
}
