namespace VsoApi.MsAgile.Entities.Mappings
{
    using System;
    using System.Linq;
    using AutoMapper;
    using VsoApi.Contracts.Models;

    internal static class BaseWorkItemMapping
    {
        internal static void Configure()
        {
            Mapper.CreateMap<WorkItem, BaseWorkItemEntity>()
                .ForMember(entity => entity.ActivatedBy, option => option.MapFrom(workitem => workitem.Fields.VstsActivatedBy))
                .ForMember(entity => entity.ActivatedDate, option => option.MapFrom(workitem => workitem.Fields.VstsActivatedDate))
                .ForMember(entity => entity.AreaId, option => option.MapFrom(workitem => workitem.Fields.SystemAreaId))
                .ForMember(entity => entity.AreaPath, option => option.MapFrom(workitem => workitem.Fields.SystemAreaPath))
                .ForMember(entity => entity.AssignedTo, option => option.MapFrom(workitem => workitem.Fields.SystemAssignedTo))
                .ForMember(entity => entity.AttachedFileCount,
                    option => option.MapFrom(workitem => workitem.Fields.SystemAttachedFileCount))
                .ForMember(entity => entity.AuthorizedAs, option => option.MapFrom(workitem => workitem.Fields.SystemAuthorizedAs))
                .ForMember(entity => entity.AuthorizedDate,
                    option => option.MapFrom(workitem => workitem.Fields.SystemAuthorizedDate))
                .ForMember(entity => entity.BisLinks, option => option.MapFrom(workitem => workitem.Fields.SystemBisLinks))
                .ForMember(entity => entity.ChangedBy, option => option.MapFrom(workitem => workitem.Fields.SystemChangedBy))
                .ForMember(entity => entity.ChangedDate, option => option.MapFrom(workitem => workitem.Fields.SystemChangedDate))
                .ForMember(entity => entity.ClosedBy, option => option.MapFrom(workitem => workitem.Fields.VstsClosedBy))
                .ForMember(entity => entity.ClosedDate, option => option.MapFrom(workitem => workitem.Fields.VstsClosedDate))
                .ForMember(entity => entity.CreatedBy, option => option.MapFrom(workitem => workitem.Fields.SystemCreatedBy))
                .ForMember(entity => entity.CreatedDate, option => option.MapFrom(workitem => workitem.Fields.SystemCreatedDate))
                .ForMember(entity => entity.Description, option => option.MapFrom(workitem => workitem.Fields.SystemDescription))
                .ForMember(entity => entity.ExternalLinkCount,
                    option => option.MapFrom(workitem => workitem.Fields.SystemExternalLinkCount))
                .ForMember(entity => entity.History, option => option.MapFrom(workitem => workitem.Fields.SystemHistory))
                .ForMember(entity => entity.Id, option => option.MapFrom(workitem => workitem.Id))
                .ForMember(entity => entity.IntegrationBuild,
                    option => option.MapFrom(workitem => workitem.Fields.VstsIntegrationBuild))
                .ForMember(entity => entity.IterationId, option => option.MapFrom(workitem => workitem.Fields.SystemIterationId))
                .ForMember(entity => entity.IterationPath,
                    option => option.MapFrom(workitem => workitem.Fields.SystemIterationPath))
                .ForMember(entity => entity.NodeName, option => option.MapFrom(workitem => workitem.Fields.SystemNodeName))
                .ForMember(entity => entity.Reason, option => option.MapFrom(workitem => workitem.Fields.SystemReason))
                .ForMember(entity => entity.RelatedLinkCount,
                    option => option.MapFrom(workitem => workitem.Fields.SystemRelatedLinkCount))
                .ForMember(entity => entity.Rev, option => option.MapFrom(workitem => workitem.Fields.SystemRev))
                .ForMember(entity => entity.RevisedDate, option => option.MapFrom(workitem => workitem.Fields.SystemRevisedDate))
                .ForMember(entity => entity.StackRank, option => option.MapFrom(workitem => workitem.Fields.VstsStackRank))
                .ForMember(entity => entity.State, option => option.MapFrom(workitem => workitem.Fields.SystemState))
                .ForMember(entity => entity.StateChangeDate,
                    option => option.MapFrom(workitem => workitem.Fields.VstsStateChangeDate))
                .ForMember(entity => entity.TeamProject, option => option.MapFrom(workitem => workitem.Fields.SystemTeamProject))
                .ForMember(entity => entity.Title, option => option.MapFrom(workitem => workitem.Fields.SystemTitle))
                .ForMember(entity => entity.Watermark, option => option.MapFrom(workitem => workitem.Fields.SystemWatermark))
                .AfterMap((workItem, entity) => entity.Tags = workItem.Fields.SystemTags != null
                    ? workItem.Fields.SystemTags.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                    : Enumerable.Empty<string>());
            
        }
    }
}