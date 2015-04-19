namespace VsoApi.MsAgile.Entities.Mappings
{
    using AutoMapper;
    using VsoApi.Contracts.Models;

    internal static class UserStoryMapping
    {
        internal static void Configure()
        {
            Mapper.CreateMap<WorkItem, UserStory>()
                .IncludeBase<WorkItem, BaseEntity>() // reuse mapping for base class
                .ForMember(userStory => userStory.Risk, option => option.MapFrom(workItem => workItem.Fields.VstsRisk))
                .ForMember(userStory => userStory.ResolvedBy, option => option.MapFrom(workItem => workItem.Fields.VstsResolvedBy))
                .ForMember(userStory => userStory.ResolvedDate, option => option.MapFrom(workItem => workItem.Fields.VstsResolvedDate))
                .ForMember(userStory => userStory.ResolvedReason, option => option.MapFrom(workItem => workItem.Fields.VstsResolvedReason))
                .ForMember(userStory => userStory.StoryPoints, option => option.MapFrom(workItem => workItem.Fields.VstsStoryPoints))
                .ForMember(userStory => userStory.FinishDate, option => option.MapFrom(workItem => workItem.Fields.VstsFinishDate))
                .ForMember(userStory => userStory.StartDate, option => option.MapFrom(workItem => workItem.Fields.VstsStartDate));
        }
    }
}