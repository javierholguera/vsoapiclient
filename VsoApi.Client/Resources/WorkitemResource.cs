namespace VsoApi.Client.Resources
{
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class WorkitemResource : IWorkitemResource
    {
        private readonly IRestClient _client;

        public WorkitemResource(IRestClient client)
        {
            _client = client;
        }

        private static string QueryResourceUri
        {
            get { return "_apis/wit/workitems"; }
        }

        private static string ModificationResourceUri
        {
            get { return "{project}/_apis/wit/workitems/"; }
        }

        public ListResponse<Workitem> GetAll(WorkitemListRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<ListResponse<Workitem>>(restResponse.Content);
        }

        public Workitem Get(WorkitemRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<Workitem>(restResponse.Content);
        }

        public Workitem Patch(WorkitemCreateRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(ModificationResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<Workitem>(restResponse.Content);
        }
    }
}