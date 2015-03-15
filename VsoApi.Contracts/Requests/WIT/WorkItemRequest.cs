namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Globalization;
    using RestSharp;

    public class WorkItemRequest : VsoRequest
    {
        // Query string: [/{Id}?$expand={enum{relations}]

        public WorkItemRequest(uint workItemId, WorkItemExpandType expand = WorkItemExpandType.None)
            : base(string.Empty)
        {
            WorkItemId = workItemId;
            Expand = expand;
        }

        private uint WorkItemId { get; set; }
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

            restRequest.AddUrlSegment("Id", WorkItemId.ToString(CultureInfo.InvariantCulture));
            restRequest.AddQueryParameter("$expand", Expand.ToString());
        }
    }
}