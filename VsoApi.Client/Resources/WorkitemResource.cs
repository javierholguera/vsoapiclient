namespace VsoApi.Client.Resources
{
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class WorkItemResource : IWorkItemResource
    {
        private readonly IRestClient _client;

        public WorkItemResource(IRestClient client)
        {
            _client = client;
        }

        private string QueryResourceUri
        {
            get { return "_apis/wit/workitems"; }
        }

        private string CreationResourceUri
        {
            get { return "{project}/_apis/wit/workitems/"; }
        }

        private string ModificationResourceUri
        {
            get { return "_apis/wit/workitems/{id}"; }
        }

        public ListResponse<WorkItem> GetAll(WorkItemListRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<ListResponse<WorkItem>>(restResponse.Content);
        }

        public WorkItem Get(WorkItemRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItem>(restResponse.Content);
        }

        public WorkItem Patch(WorkItemCreateRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(CreationResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItem>(restResponse.Content);
        }
        
        public WorkItem Patch(WorkItemUpdateRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(ModificationResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItem>(restResponse.Content);
        }
    }
}