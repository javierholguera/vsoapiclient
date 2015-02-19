namespace VsoApi.Contracts.Requests
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RestSharp;

    public class EmptyRequest : VsoRequest
    {
        public override IRestRequest GetRestRequest(string resourceUri)
        {
            IRestRequest request = new RestRequest(resourceUri, Method.GET);
            request.AddQueryParameter("api-version", ApiVersion);
            return request;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }
    }
}