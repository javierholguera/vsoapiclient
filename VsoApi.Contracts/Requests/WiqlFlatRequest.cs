namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using RestSharp;

    public class WiqlFlatRequest : VsoRequest
    {
        public Body RequestBody { get; set; }

        protected override Method Method
        {
            get { return Method.POST; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(RequestBody), ParameterType.RequestBody);
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