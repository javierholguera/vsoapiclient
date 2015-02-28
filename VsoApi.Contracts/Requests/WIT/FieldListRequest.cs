namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using RestSharp;

    public class FieldListRequest : VsoRequest
    {
        public FieldListRequest(string fieldName) : base(string.Empty)
        {
            if (fieldName == null)
                throw new ArgumentNullException("fieldName");

            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("Field name is mandatory to request a list of fields", "fieldName");

            FieldName = fieldName;
        }

        private string FieldName { get; set; }

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
    }
}