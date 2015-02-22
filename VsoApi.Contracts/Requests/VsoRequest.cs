namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RestSharp;

    public abstract class VsoRequest : IValidatableObject
    {
        // Paramater "api-version"
        public string ApiVersion { get { return "1.0"; } }

        public abstract IRestRequest GetRestRequest(Uri resourceUri);

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}