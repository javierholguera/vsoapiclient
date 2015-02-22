
namespace VsoApi.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using RestSharp;

    public class WorkItemListRequest : VsoRequest
    {
        // Query string: [&ids={string}&Fields={string}&asof={datetime}&$expand={enum{relations}]

        public WorkItemListRequest()
        {
            Ids = new Collection<string>();
            Fields = new Collection<string>();
            Expand = WorkItemExpandRequest.None;
        }
        
        public ICollection<string> Ids { get; private set; }
        public ICollection<string> Fields { get; private set; }
        public DateTime? AsOf { get; set; }
        public WorkItemExpandRequest Expand { get; set; }
        
        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            if (Ids.Any())
                restRequest.AddQueryParameter("ids", string.Join(",", Ids));
            if (Fields.Any())
                restRequest.AddQueryParameter("Fields", string.Join(",", Fields));
            if (AsOf != null)
                restRequest.AddQueryParameter("asof", AsOf.Value.ToString(CultureInfo.InvariantCulture));

            restRequest.AddQueryParameter("$expand", Expand.ToString());
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Ids.Any() == false)
                yield return new ValidationResult("Unable to request an empty list of workItem ids", new[] { "Ids" });
            
            if (AsOf != null && Fields.Any() == false)
                yield return new ValidationResult("The asOf parameter can only be used with the Fields parameter", new[] { "AsOf" });

            yield return ValidationResult.Success;
        }
    }
}
