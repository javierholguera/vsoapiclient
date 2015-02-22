

namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using RestSharp;

    public class WorkItemUpdateRequest : VsoRequest
    {
        public string Id { get; set; }

        public IEnumerable<FieldEntry> Body { get; set; } 

        protected override Method Method
        {
            get { return Method.PATCH; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{Id}";
            restRequest.AddUrlSegment("Id", Id);

            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            restRequest.AddParameter(
                "application/json-patch+json", JsonConvert.SerializeObject(Body), ParameterType.RequestBody);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Id))
                yield return new ValidationResult("Unable to process a workItem update request without workItem ID", new[] { "Id" });

            yield return ValidationResult.Success;
        }
    }
}
