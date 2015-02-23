
namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RestSharp;

    public class WorkItemTypeRequest : VsoRequest
    {
        // Query string: [/{Id}]

        public string Name { get; set; }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{name}";
            restRequest.AddUrlSegment("name", Name);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("Unable to request a work item type with an empty name", new[] { "Name" });
            
            if (string.IsNullOrWhiteSpace(Project))
                yield return new ValidationResult("Unable to request a work item type with an empty project", new[] { "Project" });

            yield return ValidationResult.Success;
        }
    }
}
