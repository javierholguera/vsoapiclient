namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using RestSharp;

    public class WorkItemRequest : VsoRequest
    {
        // Query string: [/{Id}?$expand={enum{relations}]

        public WorkItemRequest(string workItemId, WorkItemExpandType expand = WorkItemExpandType.None)
            : base(string.Empty)
        {
            if (workItemId == null)
                throw new ArgumentNullException("workItemId");

            if (string.IsNullOrWhiteSpace(workItemId))
                throw new ArgumentException("Work Item Id is mandatory to request a work item", "workItemId");

            WorkItemId = workItemId;
            Expand = expand;
        }

        private string WorkItemId { get; set; }
        private WorkItemExpandType Expand { get; set; }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{Id}";

            restRequest.AddUrlSegment("Id", WorkItemId);
            restRequest.AddQueryParameter("$expand", Expand.ToString());
        }
    }
}