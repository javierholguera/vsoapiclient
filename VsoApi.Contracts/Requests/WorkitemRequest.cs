
namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RestSharp;

    public class WorkItemRequest : VsoRequest
    {
        // Query string: [/{Id}?$expand={enum{relations}]

        public WorkItemRequest()
        {
            Expand = WorkItemExpandRequest.None;
        }

        public string Id { get; set; }
        public WorkItemExpandRequest Expand { get; set; }
        
        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{Id}";

            restRequest.AddUrlSegment("Id", Id);
            restRequest.AddQueryParameter("$expand", Expand.ToString());
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Id))
                yield return new ValidationResult("Unable to request a workItem with an empty Id", new[] { "Id" });

            yield return ValidationResult.Success;
        }
    }
}
