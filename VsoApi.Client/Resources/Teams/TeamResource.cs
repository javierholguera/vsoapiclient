namespace VsoApi.Client.Resources.Teams
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests.Team;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Team;

    public class TeamResource : BaseResource, ITeamResource
    {
        public TeamResource(IRestClient requestClient) : base(requestClient)
        {
        }

        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/projects/{project}/teams", UriKind.Relative); }
        }

        public CollectionResponse<Team> GetAll(TeamListRequest request)
        {
            return Call<TeamListRequest, CollectionResponse<Team>>(request);
        }
    }
}