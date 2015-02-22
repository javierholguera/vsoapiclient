namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Newtonsoft.Json;
    using RestSharp;

    public class WiqlFlatRequest : VsoRequest
    {
        public Body RequestBody { get; set; }

        public override IRestRequest GetRestRequest(Uri resourceUri)
        {
            List<ValidationResult> validationResult = Validate(new ValidationContext(this)).ToList();
            if (validationResult.Any())
                throw new InvalidOperationException(string.Join(Environment.NewLine, validationResult.Select(r => r.ToString())));

            IRestRequest request = new RestRequest(resourceUri, Method.POST);
            request.AddQueryParameter("api-version", ApiVersion);

            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            request.AddParameter("application/json", JsonConvert.SerializeObject(RequestBody), ParameterType.RequestBody);

            return request;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(RequestBody.Query))
                yield return new ValidationResult("Unable to execute a WIQL flat query without query value", new[] { "RequestBody.Query" });
        }
    }

    public class Body
    {
        public string Query { get; set; }
    }
}