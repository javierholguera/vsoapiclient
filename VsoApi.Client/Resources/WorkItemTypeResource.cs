namespace VsoApi.Client.Resources
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class WorkItemTypeResource : BaseResource, IWorkItemTypeResource
    {
        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/wit/workitemtypes", UriKind.Relative); }
        }

        public WorkItemTypeResource(IRestClient client) : base(client)
        {
        }

        public CollectionResponse<WorkItemType> GetAll(WorkItemTypeListRequest request)
        {
            return Call<WorkItemTypeListRequest, CollectionResponse<WorkItemType>>(request);
        }

        public WorkItemType Get(WorkItemTypeRequest request)
        {
            return Call<WorkItemTypeRequest, WorkItemType>(request);
        }
    }
}