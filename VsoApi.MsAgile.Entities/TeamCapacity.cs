

namespace VsoApi.MsAgile.Entities
{
    using System;
    using System.Collections.Generic;

    public class TeamCapacity : BaseEntity
    {
        public int DaysOff { get; set; }
        public IEnumerable<CapacityEntry> Entries { get; set; }

        public Guid IterationId { get; set; }
    }

    public class CapacityEntry
    {
        public string TeamMember { get; set; }
        public decimal AvailableHours { get; set; }
        public int DaysOff { get; set; }
    }
}