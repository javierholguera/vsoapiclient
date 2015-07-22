using System;
using System.Collections.Generic;
using System.Linq;
using VsoApi.Contracts.Requests.Work;
using VsoApi.Contracts.Responses;
using VsoApi.Contracts.Responses.Work;
using Xunit;

namespace VsoApi.Client.Tests.Work
{
    public class GetTeamCapacityTests
    {
        [Fact]
        public void GetTeamCapacity()
        {
            var client = new VsoClient();
            CollectionResponse<TeamMemberCapacity> result = client.CapacityResources.GetAll(new CapacityInfoRequest(
                "Personal",
                "Personal Team",
                Guid.Parse("cebb79f1-dac5-4d09-9c7f-7e63cd412b6c"))); // corresponds to Iteration 1

            Assert.Equal(1, result.Count);

            List<TeamMemberCapacity> entries = result.Value.ToList();
            TeamMemberCapacity memberCapacity = entries.Single();
            Assert.Equal("Javier Holguera", memberCapacity.TeamMember.DisplayName);
            Assert.Equal("jholguerablanco@hotmail.com", memberCapacity.TeamMember.UniqueName);
            var daysOff = memberCapacity.DaysOff.ToList();
            Assert.Equal(1, daysOff.Count);
            Assert.Equal(daysOff[0].Start, new DateTimeOffset(2015, 03, 30, 0, 0, 0, TimeSpan.Zero));
            Assert.Equal(daysOff[0].End, new DateTimeOffset(2015, 03, 30, 0, 0, 0, TimeSpan.Zero));
        }

        [Fact]
        public void GetTeamMemberCapacity()
        {
            var client = new VsoClient();
            TeamMemberCapacity memberCapacity = client.CapacityResources.Get(new TeamMemberCapacityRequest(
                "Personal",
                "Personal Team",
                Guid.Parse("cebb79f1-dac5-4d09-9c7f-7e63cd412b6c"),  // corresponds to Iteration 1
                Guid.Parse("ad01adb5-48a4-4ce5-bde2-f9cfc81430a0")));  // corresponds to Javier

            Assert.Equal("Javier Holguera", memberCapacity.TeamMember.DisplayName);
            Assert.Equal("jholguerablanco@hotmail.com", memberCapacity.TeamMember.UniqueName);
            var daysOff = memberCapacity.DaysOff.ToList();
            Assert.Equal(1, daysOff.Count);
            Assert.Equal(daysOff[0].Start, new DateTimeOffset(2015, 03, 30, 0, 0, 0, TimeSpan.Zero));
            Assert.Equal(daysOff[0].End, new DateTimeOffset(2015, 03, 30, 0, 0, 0, TimeSpan.Zero));
        }
    }
}