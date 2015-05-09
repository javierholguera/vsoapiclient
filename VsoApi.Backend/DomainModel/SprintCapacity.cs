namespace VsoApi.Backend.DomainModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Sprint
    {
        public Sprint()
        {
            MemberCapacities = new Collection<MemberCapacity>();
        }

        public int SprintId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MemberCapacity> MemberCapacities { get; set; } 
    }

    public class MemberCapacity
    {
        public int MemberCapacityId { get; set; }

        public int TeamMemberId { get; set; }
        public virtual TeamMember TeamMember { get; set; }

        public int SprintId { get; set; }
        public virtual Sprint Sprint { get; set; }

        public decimal Capacity { get; set; }
    }

    public class TeamMember
    {
        public TeamMember()
        {
            Capacities = new Collection<MemberCapacity>();
        }

        public int TeamMemberId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MemberCapacity> Capacities { get; set; } 
    }
}