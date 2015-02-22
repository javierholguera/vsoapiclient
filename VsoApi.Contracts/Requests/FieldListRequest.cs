namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using RestSharp;

    public class FieldListRequest : VsoRequest
    {
        public string FieldName { get; set; }

        public override IRestRequest GetRestRequest(Uri resourceUri)
        {
            List<ValidationResult> validationResult = Validate(new ValidationContext(this)).ToList();
            if (validationResult.Any())
                throw new InvalidOperationException(string.Join(Environment.NewLine, validationResult.Select(r => r.ToString())));

            IRestRequest request = new RestRequest(resourceUri + "/{fieldname}", Method.GET);

            request.AddQueryParameter("api-version", ApiVersion);
            request.AddUrlSegment("fieldname", FieldName);
            return request;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(FieldName))
                yield return new ValidationResult("Unable to request field information without field name");
        }
    }
}