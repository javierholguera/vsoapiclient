
namespace VsoApi.Contracts.Requests.WIT
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RestSharp;

    public class WorkItemTypeListRequest : VsoRequest
    {
        protected override Method Method { get { return Method.GET; } }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Project))
                yield return new ValidationResult("Unable to request a work item type with an empty project", new[] { "Project" });

            yield return ValidationResult.Success;
        }
    }
}
