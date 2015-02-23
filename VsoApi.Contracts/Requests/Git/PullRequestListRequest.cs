

namespace VsoApi.Contracts.Requests.Git
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RestSharp;

    public class PullRequestListRequest : VsoRequest
    {
        protected override string ApiVersion
        {
            get { return "1.0-preview.1"; }
        }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        public string Repository { get; set; }
        
        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{repository}/pullrequests";
            restRequest.AddUrlSegment("repository", Repository);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Repository))
                yield return new ValidationResult("Unable to request a list of pull requests without repository", new[] { "Repository" });

            yield return ValidationResult.Success;
        }
    }
}
