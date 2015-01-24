using System.Collections.Generic;
using VsoApi.Contracts.Models;

namespace VsoApi.Contracts.Responses
{
    public class ListResponse<T> where T : VsoEntity
    {
        public int Count { get; set; }
        public List<T> Value { get; set; }
    }
}
