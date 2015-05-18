namespace VsoApi.MsAgile.Entities
{
    using System.Collections.Generic;

    public class Capacity : BaseEntity
    {
        public string IterationName { get; set; }
        public IEnumerable<CapacityEntry> Entries { get; set; }
    }

    public class CapacityEntry
    {
        public string TeamMember { get; set; }
        public decimal AvailableHours { get; set; }
    }
}