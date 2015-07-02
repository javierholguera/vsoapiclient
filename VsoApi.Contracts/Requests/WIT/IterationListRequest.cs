namespace VsoApi.Contracts.Requests.WIT
{
    public class IterationListRequest : ClassificationNodeListRequest
    {
        public IterationListRequest(string project) : base(project, ClassificationNodeType.Iteration)
        {
        }

        public IterationListRequest(string project, int depth)
            : base(project, ClassificationNodeType.Iteration, depth)
        {
        }

        public IterationListRequest(string project, string nodePath, int depth)
            : base(project, ClassificationNodeType.Iteration, nodePath, depth)
        {
        }
    }
}