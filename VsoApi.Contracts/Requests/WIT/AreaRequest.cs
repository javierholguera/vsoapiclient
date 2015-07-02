namespace VsoApi.Contracts.Requests.WIT
{
    public class AreaRequest : ClassificationNodeListRequest
    {
        public AreaRequest(string project, string iterationName) :
            base(project, ClassificationNodeType.Area, iterationName, 1)
        {
        }

        public AreaRequest(string project, string iterationName, int depth) :
            base(project, ClassificationNodeType.Area, iterationName, depth)
        {
        }
    }
}