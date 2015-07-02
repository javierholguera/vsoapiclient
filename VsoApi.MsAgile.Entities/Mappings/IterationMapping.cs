using System;
using System.Linq;

namespace VsoApi.MsAgile.Entities.Mappings
{
    using AutoMapper;
    using VsoApi.Contracts.Responses.WIT;

    internal static class IterationMapping
    {
        internal static void Configure()
        {
            Mapper.CreateMap<ClassificationNodeResponse, Iteration>()
                .ConstructUsing(node => Map(node, null));
        }

        private static Iteration Map(ClassificationNodeResponse node, Iteration parent)
        {
            Iteration iteration = new Iteration(node.Id) {
                Name = node.Name,
                Parent = parent,
                StartDate = node.Attributes != null ? node.Attributes.StartDate : (DateTimeOffset?)null,
                FinishDate = node.Attributes != null ? node.Attributes.FinishDate : (DateTimeOffset?)null
            };

            if (node.HasChildren)
                iteration.Children = node.Children.Select(childNode => Map(childNode, iteration)).ToList();

            return iteration;
        }
    }
}