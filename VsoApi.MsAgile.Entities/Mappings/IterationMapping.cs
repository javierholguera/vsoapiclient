namespace VsoApi.MsAgile.Entities.Mappings
{
    using AutoMapper;
    using VsoApi.Contracts.Responses.WIT;

    internal static class IterationMapping
    {
        internal static void Configure()
        {
            Mapper.CreateMap<ClassificationNodeResponse, Iteration>()
                .ForMember(entity => entity.Id, option => option.MapFrom(classificationNode => classificationNode.Id))
                .ForMember(entity => entity.Name, option => option.MapFrom(classificationNode => classificationNode.Name))
                .ForMember(entity => entity.StartDate, option => option.MapFrom(classificationNode => classificationNode.Attributes.StartDate))
                .ForMember(entity => entity.FinishDate, option => option.MapFrom(classificationNode => classificationNode.Attributes.FinishDate))
                .ForMember(entity => entity.Children, option => option.MapFrom(classificationNode => classificationNode.Children));
        }
    }
}