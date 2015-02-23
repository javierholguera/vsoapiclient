namespace VsoApi.Contracts.Responses.WIT
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;

    public class WorkItemType : VsoEntity
    {
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public string XmlForm { get; private set; }

        [JsonProperty]
        public IEnumerable<WorkItemField> FieldInstances { get; private set; }

        [JsonProperty]
        public WorkItemWorkflow Transitions { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }
}