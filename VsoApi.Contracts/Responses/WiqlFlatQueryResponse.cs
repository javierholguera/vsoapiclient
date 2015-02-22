
namespace VsoApi.Contracts.Responses
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WiqlFlatQueryResponse
    {
        [JsonProperty]
        public string QueryType { get; private set; }

        [JsonProperty]
        public DateTime AsOf { get; private set; }

        [JsonProperty]
        public IEnumerable<ColumnEntry> Columns { get; private set; }

        [JsonProperty]
        public IEnumerable<SortColumnEntry> SortColumns { get; private set; }

        [JsonProperty]
        public IEnumerable<WorkItemEntry> WorkItems { get; private set; }
    }

    public class SortColumnEntry
    {
        [JsonProperty]
        public ColumnEntry Field { get; private set; }

        [JsonProperty]
        public bool Descending { get; private set; }
    }

    public class ColumnEntry
    {
        [JsonProperty]
        public string ReferenceName { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }

    public class WorkItemEntry
    {
        [JsonProperty]
        public string Id { get; private set; }

        [JsonProperty]
        public Uri Url { get; private set; }
    }
}
