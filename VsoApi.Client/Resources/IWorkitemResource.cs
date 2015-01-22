using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsoApi.Client.Resources
{
    using System.Globalization;
    using System.Net;
    using System.Security.Cryptography;
    using RestSharp;
    using RestSharp.Deserializers;
    using VsoApi.Contracts;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IWorkitemResource
    {
        VsoResponse<Workitem> GetAll(GetListOfWorkitems request);
    }

    public class WorkitemResource : IWorkitemResource
    {
        private IRestClient _client;

        public WorkitemResource(IRestClient client)
        {
            _client = client;
        }

        public string ResourceUri
        {
            get { return "/wit/workitems"; }
        }

        public VsoResponse<Workitem> GetAll(GetListOfWorkitems request)
        {
            IRestRequest restRequest = GetRestRequest(request);
            IRestResponse restResponse = _client.Execute(restRequest);
            var deserializer = new JsonDeserializer();
            return deserializer.Deserialize<VsoResponse<Workitem>>(restResponse);
        }

        private IRestRequest GetRestRequest(GetListOfWorkitems requestData)
        {
            IRestRequest restRequest = new RestRequest(ResourceUri, Method.GET);

            restRequest.AddQueryParameter("api-version", requestData.ApiVersion);
            if (requestData.Ids.Any())
                restRequest.AddQueryParameter("ids", string.Join(",", requestData.Ids));
            if (requestData.Fields.Any())
                restRequest.AddQueryParameter("fields", string.Join(",", requestData.Fields));
            if (requestData.AsOf != null)
                restRequest.AddQueryParameter("asof", requestData.AsOf.Value.ToString(CultureInfo.InvariantCulture));
            return restRequest;
        }
    }
}
