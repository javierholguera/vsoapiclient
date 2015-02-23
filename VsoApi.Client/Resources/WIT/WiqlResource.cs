namespace VsoApi.Client.Resources.WIT
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.WIT;

    public class WiqlResource : BaseResource, IWiqlResource
    {
        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/wit/wiql", UriKind.Relative); }
        }

        public WiqlResource(IRestClient client) : base(client)
        {
        }

        public WiqlFlatQueryResponse Post(WiqlFlatRequest request)
        {
            return Call<WiqlFlatRequest, WiqlFlatQueryResponse>(request);
        }
    }
}