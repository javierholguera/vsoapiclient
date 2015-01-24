﻿
namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using RestSharp;

    public class WorkitemRequest : VsoRequest
    {
        // Query string: [/{Id}?$expand={enum{relations}]

        public string Id { get; set; }

        public override IRestRequest GetRestRequest(string resourceUri)
        {
            List<ValidationResult> validationResult = Validate(new ValidationContext(this)).ToList();
            if (validationResult.Any())
                throw new InvalidOperationException(string.Join(Environment.NewLine, validationResult.Select(r => r.ToString())));

            IRestRequest restRequest = new RestRequest(resourceUri + "/{Id}", Method.GET);
            restRequest.AddUrlSegment("Id", Id);
            restRequest.AddQueryParameter("api-version", ApiVersion);
        
            return restRequest;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Id))
                yield return new ValidationResult("Unable to request a workitem with an empty Id", new[] { "Id" });
        }
    }
}