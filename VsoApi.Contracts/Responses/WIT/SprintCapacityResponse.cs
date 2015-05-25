namespace VsoApi.Contracts.Responses.WIT
{
    using System.Collections.Generic;

    public class SprintCapacityResponse
    {
        public string Name { get; set; }
        public int SupportDays { get; set; }
        public IEnumerable<CapacityInfo> CapacityInfos { get; set; }
    }

    public class CapacityInfo
    {
        public string TeamMemberName { get; set; }
        public decimal Capacity { get; set; }
    }
}