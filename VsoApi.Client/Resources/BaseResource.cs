
namespace VsoApi.Client.Resources
{
    using System;
    using System.Net;
    using System.Web;
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Requests;

    public abstract class BaseResource
    {
        private readonly IRestClient _client;
        protected abstract Uri ResourceUri { get; }

        protected BaseResource(IRestClient requestClient)
        {
            if (requestClient == null)
                throw new ArgumentNullException("requestClient");

            _client = requestClient;
        }

        protected TResponse Call<TRequest, TResponse>(TRequest request)
            where TRequest : VsoRequest
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IRestRequest restRequest = request.GetRestRequest(ResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            if (restResponse.StatusCode >= HttpStatusCode.Ambiguous)
                throw new HttpException((int)restResponse.StatusCode, restResponse.Content);

            return JsonConvert.DeserializeObject<TResponse>(restResponse.Content);
        }
    }
}
