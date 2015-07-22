using System;
using System.Collections.Generic;
using VsoApi.Contracts.Models;
using VsoApi.Contracts.Responses.Team;

namespace VsoApi.Contracts.Responses.Work
{
    public class TeamMemberCapacity : VsoEntity
    {
        public Member TeamMember { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
        public IEnumerable<DaysOff> DaysOff { get; set; }
        public Uri Url { get; set; }
    }

    public struct Activity
    {
        public string Name { get; set; }
        public decimal CapacityPerDay { get; set; }
    }
}