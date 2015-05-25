namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using RestSharp;
    using RestSharp.Contrib;

    public class SprintCapacityRequest : VsoRequest
    {
        public SprintCapacityRequest(string iterationPath)
            : base(string.Empty)
        {
            if (iterationPath == null)
                throw new ArgumentNullException("iterationPath");

            if (string.IsNullOrWhiteSpace(iterationPath))
                throw new ArgumentException("A sprint capacity request cannot be created with an empty iteration path value");

            IterationPath = iterationPath;
        }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        public string IterationPath { get; private set; }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{iterationPath}";
            restRequest.AddUrlSegment("iterationPath", IterationPath);
        }
    }
}