namespace VsoApi.Backend.Contracts
{
    using System.Collections.Generic;

    public class SprintInfo
    {
        public string Name { get; set; }
        public IEnumerable<MemberCapacityInfo> CapacityInfos { get; set; }
    }

    public class MemberCapacityInfo
    {
        public string TeamMemberName { get; set; }
        public decimal Capacity { get; set; }
    }
}