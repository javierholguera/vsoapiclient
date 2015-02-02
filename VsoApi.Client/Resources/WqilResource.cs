namespace VsoApi.Client.Resources
{
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class WqilResource : IWqilResource
    {
        private readonly IRestClient _client;

        public WqilResource(IRestClient client)
        {
            _client = client;
        }

        private const string FlatQueryResourceUri = "_apis/wit/wiql";

        public WiqlFlatQueryResponse Post(WqilFlatRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(FlatQueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WiqlFlatQueryResponse>(restResponse.Content);
        }
    }
}