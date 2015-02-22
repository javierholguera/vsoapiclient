namespace VsoApi.Client.Resources
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

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