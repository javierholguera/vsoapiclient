namespace VsoApi.Contracts.Responses.WIT
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WorkItemWorkflow
    {
        [JsonProperty(PropertyName = "")]
        public IEnumerable<Transition> Initial { get; private set; }

        [JsonProperty(PropertyName = "To Do")]
        public IEnumerable<Transition> ToDo { get; private set; }

        [JsonProperty]
        public IEnumerable<Transition> InProgress { get; private set; }

        [JsonProperty]
        public IEnumerable<Transition> Done { get; private set; }

        [JsonProperty]
        public IEnumerable<Transition> Removed { get; private set; }
    }
}