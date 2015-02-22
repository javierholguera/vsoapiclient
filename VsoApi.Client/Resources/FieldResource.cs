namespace VsoApi.Client.Resources
{
    using System;
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class FieldResource : IFieldResource
    {
        private readonly IRestClient _client;
        private readonly Uri _queryResourceUri = new Uri("_apis/wit/fields");

        public FieldResource(IRestClient client)
        {
            _client = client;
        }

        public CollectionResponse<WorkItemFieldInfo> GetAll(EmptyRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(_queryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<CollectionResponse<WorkItemFieldInfo>>(restResponse.Content);
        }

        public WorkItemFieldInfo Get(FieldListRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(_queryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItemFieldInfo>(restResponse.Content);
        }
    }
}