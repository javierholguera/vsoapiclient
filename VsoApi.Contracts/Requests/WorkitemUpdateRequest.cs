﻿

namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Newtonsoft.Json;
    using RestSharp;

    public class WorkitemUpdateRequest : VsoRequest
    {
        public class FieldEntry
        {
            public string Op { get; set; }
            public string Path { get; set; }
            public string Value { get; set; }
        }

        public string Id { get; set; }

        public IEnumerable<FieldEntry> Body { get; set; } 

        public override IRestRequest GetRestRequest(string resourceUri)
        {
            List<ValidationResult> validationResult = Validate(new ValidationContext(this)).ToList();
            if (validationResult.Any())
                throw new InvalidOperationException(string.Join(Environment.NewLine, validationResult.Select(r => r.ToString())));

            IRestRequest restRequest = new RestRequest(resourceUri, Method.PATCH);
            restRequest.AddUrlSegment("id", Id);
            restRequest.AddQueryParameter("api-version", ApiVersion);
            
            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            restRequest.AddParameter(
                "application/json-patch+json", JsonConvert.SerializeObject(Body), ParameterType.RequestBody);

            return restRequest;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Id))
                yield return new ValidationResult("Unable to process a workitem update request without workitem ID", new[] { "Id" });
        }
    }
}