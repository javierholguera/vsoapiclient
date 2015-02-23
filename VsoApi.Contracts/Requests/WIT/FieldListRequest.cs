namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RestSharp;

    public class FieldListRequest : VsoRequest
    {
        public string FieldName { get; set; }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{fieldname}";
            restRequest.AddUrlSegment("fieldname", FieldName);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(FieldName))
                yield return new ValidationResult("Unable to request field information without field name");

            yield return ValidationResult.Success;
        }
    }
}