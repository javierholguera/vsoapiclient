namespace VsoApi.MsAgile.Entities.Mappings
{
    using AutoMapper;
    using VsoApi.Contracts.Responses.WIT;

    internal static class CapacityMapping
    {
        internal static void Configure()
        {
            //Mapper.CreateMap<CapacityInfo, CapacityEntry>()
            //    .ForMember(entity => entity.TeamMember, option => option.MapFrom(capacityInfo => capacityInfo.TeamMemberName))
            //    .ForMember(entity => entity.AvailableHours, option => option.MapFrom(capacityInfo => capacityInfo.Capacity));

            //Mapper.CreateMap<SprintCapacityResponse, Capacity>()
            //    .ForMember(entity => entity.IterationName, option => option.MapFrom(capacityResponse => capacityResponse.Name))
            //    .ForMember(entity => entity.SupportDays, option => option.MapFrom(capacityResponse => capacityResponse.SupportDays))
            //    .ForMember(entity => entity.Entries, option => option.MapFrom(capacityResponse => capacityResponse.CapacityInfos));
        }
    }
}