namespace VsoApi.Client.Resources
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class FieldResource : BaseResource, IFieldResource
    {
        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/wit/fields", UriKind.Relative); }
        }

        public FieldResource(IRestClient client) : base(client)
        {
        }

        public CollectionResponse<WorkItemFieldInfo> GetAll(EmptyRequest request)
        {
            return Call<EmptyRequest, CollectionResponse<WorkItemFieldInfo>>(request);
        }

        public WorkItemFieldInfo Get(FieldListRequest request)
        {
            return Call<FieldListRequest, WorkItemFieldInfo>(request);
        }
    }
}