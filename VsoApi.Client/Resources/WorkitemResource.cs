namespace VsoApi.Client.Resources
{
    using System;
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class WorkItemResource : IWorkItemResource
    {
        private readonly IRestClient _client;
        private readonly Uri _baseResourceUri = new Uri("_apis/wit/workitems");
        private readonly Uri _creationResourceUri = new Uri("{project}/_apis/wit/workitems");

        public WorkItemResource(IRestClient client)
        {
            _client = client;
        }
        
        public CollectionResponse<WorkItem> GetAll(WorkItemListRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(_baseResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<CollectionResponse<WorkItem>>(restResponse.Content);
        }

        public WorkItem Get(WorkItemRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(_baseResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItem>(restResponse.Content);
        }

        public WorkItem Patch(WorkItemCreateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(_creationResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItem>(restResponse.Content);
        }
        
        public WorkItem Patch(WorkItemUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(_baseResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItem>(restResponse.Content);
        }
    }
}