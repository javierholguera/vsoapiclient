
namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RestSharp;

    public class WorkItemTypeListRequest : VsoRequest
    {
        public string Project { get; set; }

        public override IRestRequest GetRestRequest(Uri resourceUri)
        {
            IRestRequest restRequest = new RestRequest(resourceUri, Method.GET);
            restRequest.AddUrlSegment("project", Project);
            restRequest.AddQueryParameter("api-version", ApiVersion);
            return restRequest;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Project))
                yield return new ValidationResult("Unable to request a work item type with an empty project", new[] { "Project" });
        }
    }
}
