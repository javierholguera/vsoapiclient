namespace VsoApi.MsAgile.Entities.Mappings
{
    using AutoMapper;
    using VsoApi.Contracts.Models;

    internal static class TaskMapping
    {
        internal static void Configure()
        {
            Mapper.CreateMap<WorkItem, Task>()
                .IncludeBase<WorkItem, BaseWorkItemEntity>()
                .ForMember(task => task.Activity, option => option.MapFrom(workItem => workItem.Fields.VstsActivity))
                .ForMember(task => task.Priority, option => option.MapFrom(workItem => workItem.Fields.VstsPriority))
                .ForMember(task => task.CompletedWork, option => option.MapFrom(workItem => workItem.Fields.VstsCompletedWork))
                .ForMember(task => task.OriginalEstimate, option => option.MapFrom(workItem => workItem.Fields.VstsOriginalEstimate))
                .ForMember(task => task.RemainingWork, option => option.MapFrom(workItem => workItem.Fields.VstsRemainingWork))
                .ForMember(task => task.StartDate, option => option.MapFrom(workItem => workItem.Fields.VstsStartDate))
                .ForMember(task => task.FinishDate, option => option.MapFrom(workItem => workItem.Fields.VstsFinishDate));
        }
    }
}