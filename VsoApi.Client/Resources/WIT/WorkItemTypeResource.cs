namespace VsoApi.Client.Resources.WIT
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.WIT;

    public class WorkItemTypeResource : BaseResource, IWorkItemTypeResource
    {
        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/wit/workitemtypes", UriKind.Relative); }
        }

        public WorkItemTypeResource(IRestClient client) : base(client)
        {
        }

        public CollectionResponse<WorkItemType> GetAll(EmptyRequest request)
        {
            return Call<EmptyRequest, CollectionResponse<WorkItemType>>(request);
        }

        public WorkItemType Get(WorkItemTypeRequest request)
        {
            return Call<WorkItemTypeRequest, WorkItemType>(request);
        }
    }
}