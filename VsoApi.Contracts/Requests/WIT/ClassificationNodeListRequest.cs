namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Globalization;
    using RestSharp;

    public class ClassificationNodeListRequest : VsoRequest
    {
        public ClassificationNodeListRequest(string project, ClassificationNodeType nodeType)
            : this(project, nodeType, string.Empty, 1) { }

        public ClassificationNodeListRequest(string project, ClassificationNodeType nodeType, int depth)
            : this(project, nodeType, string.Empty, depth) { }

        public ClassificationNodeListRequest(
            string project, ClassificationNodeType nodeType, string nodePath, int depth) : base(project)
        {
            if (string.IsNullOrEmpty(project))
                throw new ArgumentNullException("project", "project cannot be null or empty for a classification node request");

            if (nodePath == null)
                throw new ArgumentNullException("nodePath");
            if (depth < 1)
                throw new ArgumentOutOfRangeException("depth", depth, "Depth must be bigger than 1");

            NodeType = nodeType;
            NodePath = nodePath;
            Depth = depth;
        }

        public ClassificationNodeType NodeType { get; private set; }
        public string NodePath { get; private set; }
        public int Depth { get; private set; }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            restRequest.AddUrlSegment("nodetype", NodeType.ToQueryParam());

            if (string.IsNullOrWhiteSpace(NodePath) == false) {
                restRequest.Resource += "/{nodepath}";
                restRequest.AddUrlSegment("nodepath", NodePath);
            }

            if (Depth > 1)
                restRequest.AddQueryParameter("$depth", Depth.ToString(CultureInfo.InvariantCulture));
        }
    }
}