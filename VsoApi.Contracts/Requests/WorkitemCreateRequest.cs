

namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Newtonsoft.Json;
    using RestSharp;

    public class WorkItemCreateRequest : VsoRequest
    {
        public string Project { get; set; }
        public string WorkItemTypeName { get; set; }
        public IEnumerable<FieldEntry> Body { get; set; } 

        public override IRestRequest GetRestRequest(Uri resourceUri)
        {
            List<ValidationResult> validationResult = Validate(new ValidationContext(this)).ToList();
            if (validationResult.Any())
                throw new InvalidOperationException(string.Join(Environment.NewLine, validationResult.Select(r => r.ToString())));

            IRestRequest request = new RestRequest(resourceUri + "/${workitemtypename}", Method.PATCH);
            
            request.AddQueryParameter("api-version", ApiVersion);
            request.AddUrlSegment("project", Project);
            request.AddUrlSegment("workitemtypename", WorkItemTypeName);
            
            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            request.AddParameter(
                "application/json-patch+json", JsonConvert.SerializeObject(Body), ParameterType.RequestBody);

            return request;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Project))
                yield return new ValidationResult("Unable to process a workItem creation request without project", new[] { "Project" });

            if (string.IsNullOrWhiteSpace(WorkItemTypeName))
                yield return new ValidationResult("Unable to process a workItem creation request without type name", new[] { "WorkItemTypeName" });
        }
    }
}
