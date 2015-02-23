namespace VsoApi.Client.Resources.WIT
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;

    public class WorkItemResource : BaseResource, IWorkItemResource
    {
        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/wit/workitems", UriKind.Relative); }
        }

        public WorkItemResource(IRestClient client) : base(client)
        {
        }

        public CollectionResponse<WorkItem> GetAll(WorkItemListRequest request)
        {
            return Call<WorkItemListRequest, CollectionResponse<WorkItem>>(request);
        }

        public WorkItem Get(WorkItemRequest request)
        {
            return Call<WorkItemRequest, WorkItem>(request);
        }

        public WorkItem Patch(WorkItemCreateRequest request)
        {
            return Call<WorkItemCreateRequest, WorkItem>(request);
        }

        public WorkItem Patch(WorkItemUpdateRequest request)
        {
            return Call<WorkItemUpdateRequest, WorkItem>(request);
        }
    }
}