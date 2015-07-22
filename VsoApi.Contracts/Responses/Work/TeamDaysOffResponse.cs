using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VsoApi.Contracts.Models;

namespace VsoApi.Contracts.Responses.Work
{
    public class TeamDaysOffResponse : VsoEntity
    {
        public IEnumerable<DaysOff> DaysOff { get; set; }
        
        public Uri Url { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public Links Links { get; private set; }
    }

    public class DaysOff
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
    }

}