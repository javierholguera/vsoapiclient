

namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Newtonsoft.Json;
    using RestSharp;

    public class WorkitemCreateRequest : VsoRequest
    {
        public class FieldEntry
        {
            public string Op { get; set; }
            public string Path { get; set; }
            public string Value { get; set; }
        }

        public string Project { get; set; }
        public string WorkItemTypeName { get; set; }
        public IEnumerable<FieldEntry> Body { get; set; } 

        public override IRestRequest GetRestRequest(string resourceUri)
        {
            List<ValidationResult> validationResult = Validate(new ValidationContext(this)).ToList();
            if (validationResult.Any())
                throw new InvalidOperationException(string.Join(Environment.NewLine, validationResult.Select(r => r.ToString())));

            IRestRequest request = new RestRequest(resourceUri + "${workitemtypename}", Method.PATCH);
            
            request.AddQueryParameter("api-version", ApiVersion);
            request.AddUrlSegment("project", Project);
            request.AddUrlSegment("workitemtypename", WorkItemTypeName);
            
            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            request.AddParameter(
                "application/json-patch+json", JsonConvert.SerializeObject(Body), ParameterType.RequestBody);

            return request;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Project))
                yield return new ValidationResult("Unable to process a workitem creation request without project", new[] { "Project" });

            if (string.IsNullOrWhiteSpace(WorkItemTypeName))
                yield return new ValidationResult("Unable to process a workitem creation request without type name", new[] { "WorkItemTypeName" });
        }
    }
}
