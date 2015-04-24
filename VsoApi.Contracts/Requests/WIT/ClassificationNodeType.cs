namespace VsoApi.Contracts.Requests.WIT
{
    using System;

    public enum ClassificationNodeType
    {
        Area = 0,
        Iteration = 1
    }

    public static class ClassificationNodeTypeExtensions
    {
        public static string ToQueryParam(this ClassificationNodeType type)
        {
            switch (type) {
                case ClassificationNodeType.Area:
                    return "areas";
                case ClassificationNodeType.Iteration:
                    return "iterations";
                default:
                    throw new ArgumentException("Classification node type not recognized: " + type);
            }
        }

        public static string ToQueryResult(this ClassificationNodeType type)
        {
            switch (type) {
                case ClassificationNodeType.Area:
                    return "area";
                case ClassificationNodeType.Iteration:
                    return "iteration";
                default:
                    throw new ArgumentException("Classification node type not recognized: " + type);
            }
        }
    }
}