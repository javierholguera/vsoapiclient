
namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using RestSharp;

    public class WorkItemTypeRequest : VsoRequest
    {
        // Query string: [/{name}]

        public WorkItemTypeRequest(string project, string name) : base(project)
        {
            if (name == null)
                throw new ArgumentNullException("name");


            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Work Item Type Name is mandatory to request information about a work item type", "name");

            Name = name;
        }

        private string Name { get; set; }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{name}";
            restRequest.AddUrlSegment("name", Name);
        }
    }
}
