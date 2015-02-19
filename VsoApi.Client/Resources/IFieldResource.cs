
namespace VsoApi.Client.Resources
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using RestSharp;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IFieldResource
    {
        ListResponse<WorkItemFieldInfo> GetAll(EmptyRequest request);
        WorkItemFieldInfo Get(FieldListRequest request);
    }

    public class WorkItemFieldInfo : VsoEntity
    {
        public string Name { get; set; }
        public string ReferenceName { get; set; }
        public string Type { get; set; }
        public bool ReadOnly { get; set; }
        public IEnumerable<SupportedOperation> SupportedOperations { get; set; }
        public Uri Url { get; set; }
    }

    public class SupportedOperation
    {
        public string ReferenceName { get; set; }
        public string Name { get; set; }
    }

    public class FieldListRequest : VsoRequest
    {
        public string FieldName { get; set; }

        public override IRestRequest GetRestRequest(string resourceUri)
        {
            List<ValidationResult> validationResult = Validate(new ValidationContext(this)).ToList();
            if (validationResult.Any())
                throw new InvalidOperationException(string.Join(Environment.NewLine, validationResult.Select(r => r.ToString())));

            IRestRequest request = new RestRequest(resourceUri + "/{fieldname}", Method.GET);

            request.AddQueryParameter("api-version", ApiVersion);
            request.AddUrlSegment("fieldname", FieldName);
            return request;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(FieldName))
                yield return new ValidationResult("Unable to request field information without field name");
        }
    }

}
