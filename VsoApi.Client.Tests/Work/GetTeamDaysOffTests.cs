using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using VsoApi.Contracts.Requests.Work;
using VsoApi.Contracts.Responses.Work;
using Xunit;

namespace VsoApi.Client.Tests.Work
{
    public class GetTeamDaysOffTests
    {
        [Fact]
        public void GetTeamDaysOff()
        {
            var client = new VsoClient();
            TeamDaysOffResponse result = client.TeamDaysOffResources.Get(new CapacityInfoRequest(
                "Personal",
                "Personal Team",
                Guid.Parse("cebb79f1-dac5-4d09-9c7f-7e63cd412b6c"))); // corresponds to Iteration 1

            Assert.NotNull(result.DaysOff);

            List<DaysOff> days = result.DaysOff.ToList();
            Assert.Equal(2, days.Count);

            Assert.Equal(days[0].Start, new DateTimeOffset(2015, 04, 02, 0, 0, 0, TimeSpan.Zero));
            Assert.Equal(days[0].End, new DateTimeOffset(2015, 04, 02, 0, 0, 0, TimeSpan.Zero));

            Assert.Equal(days[1].Start, new DateTimeOffset(2015, 04, 03, 0, 0, 0, TimeSpan.Zero));
            Assert.Equal(days[1].End, new DateTimeOffset(2015, 04, 03, 0, 0, 0, TimeSpan.Zero));
        }
    }
}