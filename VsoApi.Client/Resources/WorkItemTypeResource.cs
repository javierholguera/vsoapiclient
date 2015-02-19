namespace VsoApi.Client.Resources
{
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class WorkItemTypeResource : IWorkItemTypeResource
    {
        private readonly IRestClient _client;

        public WorkItemTypeResource(IRestClient client)
        {
            _client = client;
        }

        private string QueryResourceUri
        {
            get { return "{project}/_apis/wit/workitemtypes"; }
        }

        public ListResponse<WorkItemType> GetAll(WorkItemTypeListRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<ListResponse<WorkItemType>>(restResponse.Content);
        }

        public WorkItemType Get(WorkItemTypeRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItemType>(restResponse.Content);
        }
    }
}