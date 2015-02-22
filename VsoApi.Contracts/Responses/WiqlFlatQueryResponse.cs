
namespace VsoApi.Contracts.Responses
{
    using System;
    using System.Collections.Generic;

    public class WiqlFlatQueryResponse
    {
        public string QueryType { get; set; }
        public DateTime AsOf { get; set; }
        public IEnumerable<ColumnEntry> Columns { get; set; }
        public IEnumerable<SortColumnEntry> SortColumns { get; set; }
        public IEnumerable<WorkItemEntry> WorkItems { get; set; }
    }

    public class SortColumnEntry
    {
        public ColumnEntry Field { get; set; }
        public bool Descending { get; set; }
    }

    public class ColumnEntry
    {
        public string ReferenceName { get; set; }
        public string Name { get; set; }
        public Uri Url { get; set; }
    }

    public class WorkItemEntry
    {
        public string Id { get; set; }
        public Uri Url { get; set; }
    }
}
