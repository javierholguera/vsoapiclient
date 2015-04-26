namespace VsoApi.MsAgile.Entities.Mappings
{
    using AutoMapper;
    using VsoApi.Contracts.Models;

    internal static class BugMapping
    {
        internal static void Configure()
        {
            Mapper.CreateMap<WorkItem, Bug>()
                .IncludeBase<WorkItem, BaseWorkItemEntity>() // reuse mapping for base class
                .ForMember(bug => bug.FoundInBuild, option => option.MapFrom(workItem => workItem.Fields.VstsBuildFoundIn))
                .ForMember(bug => bug.Severity, option => option.MapFrom(workItem => workItem.Fields.VstsSeverity))
                .ForMember(bug => bug.ReproductionSteps, option => option.MapFrom(workItem => workItem.Fields.VstsReproSteps))
                .ForMember(bug => bug.SystemInfo, option => option.MapFrom(workItem => workItem.Fields.VstsSystemInfo))
                .ForMember(bug => bug.ResolvedBy, option => option.MapFrom(workItem => workItem.Fields.VstsResolvedBy))
                .ForMember(bug => bug.ResolvedDate, option => option.MapFrom(workItem => workItem.Fields.VstsResolvedDate))
                .ForMember(bug => bug.ResolvedReason, option => option.MapFrom(workItem => workItem.Fields.VstsResolvedReason))
                .ForMember(bug => bug.StoryPoints, option => option.MapFrom(workItem => workItem.Fields.VstsStoryPoints))
                .ForMember(bug => bug.Activity, option => option.MapFrom(workItem => workItem.Fields.VstsActivity))
                .ForMember(bug => bug.Priority, option => option.MapFrom(workItem => workItem.Fields.VstsPriority))
                .ForMember(bug => bug.CompletedWork, option => option.MapFrom(workItem => workItem.Fields.VstsCompletedWork))
                .ForMember(bug => bug.OriginalEstimate, option => option.MapFrom(workItem => workItem.Fields.VstsOriginalEstimate))
                .ForMember(bug => bug.RemainingWork, option => option.MapFrom(workItem => workItem.Fields.VstsRemainingWork));
        }
    }
}