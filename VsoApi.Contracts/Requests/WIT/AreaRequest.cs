namespace VsoApi.Contracts.Requests.WIT
{
    public class AreaRequest : ClassificationNodeListRequest
    {
        public AreaRequest(string project)
            : base(project, ClassificationNodeType.Area, string.Empty, 1)
        {
        }

        public AreaRequest(string project, string areaName) :
            base(project, ClassificationNodeType.Area, areaName, 1)
        {
        }

        public AreaRequest(string project, int depth) :
            base(project, ClassificationNodeType.Area, string.Empty, depth)
        {
        }

        public AreaRequest(string project, string areaName, int depth) :
            base(project, ClassificationNodeType.Area, areaName, depth)
        {
        }
    }
}