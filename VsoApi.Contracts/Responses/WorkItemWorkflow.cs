namespace VsoApi.Contracts.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WorkItemWorkflow
    {
        [JsonProperty(PropertyName = "")]
        public IEnumerable<Transition> Initial { get; set; }

        [JsonProperty(PropertyName = "To Do")]
        public IEnumerable<Transition> ToDo { get; set; }

        public IEnumerable<Transition> InProgress { get; set; }
        public IEnumerable<Transition> Done { get; set; }
        public IEnumerable<Transition> Removed { get; set; }
    }
}