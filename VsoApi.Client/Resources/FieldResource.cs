namespace VsoApi.Client.Resources
{
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class FieldResource : IFieldResource
    {
        private readonly IRestClient _client;

        public FieldResource(IRestClient client)
        {
            _client = client;
        }

        private string QueryResourceUri
        {
            get { return "_apis/wit/fields"; }
        }

        public WorkItemType Get(WorkItemTypeRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItemType>(restResponse.Content);
        }

        public ListResponse<WorkItemFieldInfo> GetAll(EmptyRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<ListResponse<WorkItemFieldInfo>>(restResponse.Content);
        }

        public WorkItemFieldInfo Get(FieldListRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItemFieldInfo>(restResponse.Content);
        }
    }
}