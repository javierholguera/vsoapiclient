
namespace VsoApi.Contracts.Responses.WIT
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using VsoApi.Contracts.Models;

    /// <summary>
    /// Class that defines the information returned when running a query.
    /// </summary>
    /// <remarks>The fields depend on the type of query:
    /// - Flat will return the WorkItems collection, but won't return WorkItemRelations info.
    /// - OneHop and Tree will do the opposite.</remarks>
    public class WiqlQueryResponse
    {
        [JsonProperty]
        public QueryType QueryType { get; private set; }

        [JsonProperty]
        public string QueryResultType { get; private set; }

        [JsonProperty]
        public DateTime AsOf { get; private set; }

        [JsonProperty]
        public IEnumerable<ColumnEntry> Columns { get; private set; }

        [JsonProperty]
        public IEnumerable<SortColumnEntry> SortColumns { get; private set; }

        [JsonProperty]
        public IEnumerable<ElementIdentity> WorkItems { get; private set; }

        [JsonProperty]
        public IEnumerable<WorkItemRelation> WorkItemRelations { get; private set; }
    }

    public enum QueryType
    {
        Flat,
        OneHop,
        Tree
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

    public class WorkItemRelation
    {
        [JsonProperty]
        public ElementIdentity Target { get; set; }

        [JsonProperty]
        public ElementIdentity Source { get; set; }

        [JsonProperty]
        public string Rel { get; private set; }
    }
}
