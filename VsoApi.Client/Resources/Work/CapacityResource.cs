using System;
using RestSharp;
using VsoApi.Contracts.Requests.Work;
using VsoApi.Contracts.Responses;
using VsoApi.Contracts.Responses.Work;

namespace VsoApi.Client.Resources.Work
{
    public class CapacityResource : BaseResource, ICapacityResource
    {
        public CapacityResource(IRestClient requestClient) : base(requestClient)
        {
        }

        protected override Uri ResourceUri
        {
            get { return new Uri("/{team}/_apis/work/teamsettings/iterations/{iterationid}/capacities", UriKind.Relative); }
        }

        public CollectionResponse<TeamMemberCapacity> GetAll(TeamCapacityRequest request)
        {
            return Call<TeamCapacityRequest, CollectionResponse<TeamMemberCapacity>>(request);
        }

        public TeamMemberCapacity Get(TeamMemberCapacityRequest request)
        {
            return Call<TeamMemberCapacityRequest, TeamMemberCapacity>(request);
        }
    }
}