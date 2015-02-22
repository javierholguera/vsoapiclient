namespace VsoApi.Client.Resources
{
    using System;
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class WiqlResource : IWiqlResource
    {
        private readonly IRestClient _client;
        private readonly Uri _flatQueryResourceUri = new Uri("_apis/wit/wiql");

        public WiqlResource(IRestClient client)
        {
            _client = client;
        }

        public WiqlFlatQueryResponse Post(WiqlFlatRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(_flatQueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WiqlFlatQueryResponse>(restResponse.Content);
        }
    }
}