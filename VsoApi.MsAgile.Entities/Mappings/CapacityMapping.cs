
namespace VsoApi.MsAgile.Entities.Mappings
{
    using System.Linq;
    using AutoMapper;
    using VsoApi.Contracts.Responses.Work;
    using VsoApi.MsAgile.Entities.Linq;

    internal static class CapacityMapping
    {
        internal static void Configure()
        {
            Mapper.CreateMap<TeamMemberCapacity, CapacityEntry>()
                .ForMember(entity => entity.TeamMember, option => option.MapFrom(capacityInfo => capacityInfo.TeamMember))
                .ForMember(entity => entity.DaysOff, option => option.MapFrom(capacityInfo => capacityInfo.DaysOff.Count()))
                .ForMember(entity => entity.AvailableHours, option => option.MapFrom(capacityInfo => capacityInfo.Activities.Sum(a => a.CapacityPerDay)));

            Mapper.CreateMap<TeamCapacityResult, TeamCapacity>()
                .ForMember(entity => entity.DaysOff, option => option.MapFrom(capacityResponse => capacityResponse.DaysOffInfo.DaysOff.Count()))
                .ForMember(entity => entity.Entries, option => option.MapFrom(capacityResponse => capacityResponse.MemberCapacities));
        }
    }
}