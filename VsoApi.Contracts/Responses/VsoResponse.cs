using System.Collections.Generic;
using VsoApi.Contracts.Models;

namespace VsoApi.Contracts.Responses
{
    public class VsoResponse<T> where T : VsoEntity
    {
        public int count { get; set; }
        public List<T> value { get; set; }
    }
}
