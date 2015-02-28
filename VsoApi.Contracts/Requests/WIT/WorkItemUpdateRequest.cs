

namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using RestSharp;

    public class WorkItemUpdateRequest : VsoRequest
    {
        public WorkItemUpdateRequest(string workItemId, IEnumerable<FieldEntry> fieldEntries)
            : base(string.Empty)
        {
            if (workItemId == null)
                throw new ArgumentNullException("workItemId");
            if (fieldEntries == null)
                throw new ArgumentNullException("fieldEntries");

            if (string.IsNullOrWhiteSpace(workItemId))
                throw new ArgumentException("Work Item Id is mandatory to update a new work item", "workItemId");

            Id = workItemId;
            FieldEntries = fieldEntries;
        }

        private string Id { get; set; }
        private IEnumerable<FieldEntry> FieldEntries { get; set; } 

        protected override Method Method
        {
            get { return Method.PATCH; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{Id}";
            restRequest.AddUrlSegment("Id", Id);

            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            restRequest.AddParameter(
                "application/json-patch+json", JsonConvert.SerializeObject(FieldEntries), ParameterType.RequestBody);
        }
    }
}
