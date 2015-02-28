
namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using RestSharp;

    public class WorkItemCreateRequest : VsoRequest
    {
        public WorkItemCreateRequest(string project, string workItemTypeName, IEnumerable<FieldEntry> fieldEntries) : base(project)
        {
            if (workItemTypeName == null)
                throw new ArgumentNullException("workItemTypeName");
            if (fieldEntries == null)
                throw new ArgumentNullException("fieldEntries");

            if (string.IsNullOrWhiteSpace(workItemTypeName))
                throw new ArgumentException("Work Item Type Name is mandatory to create a new work item", "workItemTypeName");

            WorkItemTypeName = workItemTypeName;
            FieldEntries = fieldEntries;
        }

        private string WorkItemTypeName { get; set; }
        private IEnumerable<FieldEntry> FieldEntries { get; set; }

        protected override Method Method
        {
            get { return Method.PATCH; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/${workitemtypename}";
            restRequest.AddUrlSegment("workitemtypename", WorkItemTypeName);

            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            restRequest.AddParameter(
                "application/json-patch+json", JsonConvert.SerializeObject(FieldEntries), ParameterType.RequestBody);
        }
    }
}
