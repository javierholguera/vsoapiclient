

namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using RestSharp;

    public class WorkItemCreateRequest : VsoRequest
    {
        protected override Method Method
        {
            get { return Method.PATCH; }
        }

        public string WorkItemTypeName { get; set; }
        public IEnumerable<FieldEntry> Body { get; set; }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/${workitemtypename}";
            restRequest.AddUrlSegment("workitemtypename", WorkItemTypeName);

            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            restRequest.AddParameter(
                "application/json-patch+json", JsonConvert.SerializeObject(Body), ParameterType.RequestBody);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Project))
                yield return new ValidationResult("Unable to process a workItem creation request without project", new[] { "Project" });

            if (string.IsNullOrWhiteSpace(WorkItemTypeName))
                yield return new ValidationResult("Unable to process a workItem creation request without type name", new[] { "WorkItemTypeName" });

            yield return ValidationResult.Success;
        }
    }
}
