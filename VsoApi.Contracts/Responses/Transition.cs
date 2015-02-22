namespace VsoApi.Contracts.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Transition
    {
        [JsonProperty]
        public string To { get; private set; }

        [JsonProperty]
        public IEnumerable<string> Actions { get; private set; }
    }
}