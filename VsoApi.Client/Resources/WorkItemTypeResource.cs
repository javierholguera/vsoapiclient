namespace VsoApi.Client.Resources
{
    using System;
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public class WorkItemTypeResource : IWorkItemTypeResource
    {
        private readonly IRestClient _client;
        private readonly Uri _resourceUri = new Uri("/_apis/wit/workitemtypes", UriKind.Relative);

        public WorkItemTypeResource(IRestClient client)
        {
            _client = client;
        }

        public CollectionResponse<WorkItemType> GetAll(WorkItemTypeListRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(_resourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<CollectionResponse<WorkItemType>>(restResponse.Content);
        }

        public WorkItemType Get(WorkItemTypeRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(_resourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItemType>(restResponse.Content);
        }
    }
}