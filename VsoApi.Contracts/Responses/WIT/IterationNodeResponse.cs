namespace VsoApi.Contracts.Responses.WIT
{
    using System;
    using Newtonsoft.Json;

    public class IterationNodeResponse : ClassificationNodeResponse
    {
        [JsonProperty]
        public IterationNodeResponseAttribute Attributes { get; private set; }
    }

    public class IterationNodeResponseAttribute
    {
        [JsonProperty]
        public DateTimeOffset StartDate { get; private set; }

        [JsonProperty]
        public DateTimeOffset FinishDate { get; private set; }
    }
}