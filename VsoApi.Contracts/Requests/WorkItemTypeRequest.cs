
namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using RestSharp;

    public class WorkItemTypeRequest : VsoRequest
    {
        // Query string: [/{Id}]

        public string Name { get; set; }

        public string Project { get; set; }

        public override IRestRequest GetRestRequest(string resourceUri)
        {
            List<ValidationResult> validationResult = Validate(new ValidationContext(this)).ToList();
            if (validationResult.Any())
                throw new InvalidOperationException(string.Join(Environment.NewLine, validationResult.Select(r => r.ToString())));

            IRestRequest restRequest = new RestRequest(resourceUri + "/{name}", Method.GET);
            restRequest.AddUrlSegment("project", Project);
            restRequest.AddUrlSegment("name", Name);
            restRequest.AddQueryParameter("api-version", ApiVersion);
        
            return restRequest;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("Unable to request a work item type with an empty name", new[] { "Name" });
            
            if (string.IsNullOrWhiteSpace(Project))
                yield return new ValidationResult("Unable to request a work item type with an empty project", new[] { "Project" });
        }
    }
}
