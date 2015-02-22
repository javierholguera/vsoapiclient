namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using RestSharp;

    public abstract class VsoRequest : IValidatableObject
    {
        // Paramater "api-version"
        private const string ApiVersion  = "1.0";

        public string Project { get; set; }

        protected abstract Method Method { get;}

        public IRestRequest GetRestRequest(Uri resourceUri)
        {
            List<ValidationResult> validationResult = Validate(new ValidationContext(this))
                .Where(v => v != ValidationResult.Success)
                .ToList();

            if (validationResult.Any()) {
                string message = string.Join(Environment.NewLine, validationResult.Select(validation => validation.ErrorMessage));
                throw new ArgumentException(message);
            }

            IRestRequest restRequest;
            if (string.IsNullOrWhiteSpace(Project) == false) {
                restRequest = new RestRequest(new Uri("/{project}" + resourceUri, UriKind.Relative), Method);
                restRequest.AddUrlSegment("project", Project);
            } else {
                restRequest = new RestRequest(resourceUri, Method);
            }

            restRequest.AddQueryParameter("api-version", ApiVersion);
            CompleteRequest(restRequest);
            return restRequest;
        }

        protected abstract void CompleteRequest(IRestRequest restRequest);

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}