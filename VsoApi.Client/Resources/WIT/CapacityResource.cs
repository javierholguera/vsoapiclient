namespace VsoApi.Client.Resources.WIT
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses.WIT;

    public class CapacityResource : BaseResource, ICapacityResource
    {
        public CapacityResource(IRestClient requestClient) : base(requestClient)
        {
        }

        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/wit/capacity", UriKind.Relative); }
        }

        public SprintCapacityResponse Get(SprintCapacityRequest request)
        {
            return Call<SprintCapacityRequest, SprintCapacityResponse>(request);
        }

        public SprintCapacityResponse Post(SetSprintCapacityRequest request)
        {
            return Call<SetSprintCapacityRequest, SprintCapacityResponse>(request);
        }
    }
}