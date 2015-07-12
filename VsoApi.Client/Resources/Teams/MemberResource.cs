namespace VsoApi.Client.Resources.Teams
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Requests.Team;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Team;

    public class MemberResource : BaseResource, IMemberResource
    {
        public MemberResource(IRestClient requestClient) : base(requestClient)
        {
        }

        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/projects/{project}/teams/{team}/members", UriKind.Relative); }
        }

        public CollectionResponse<Member> GetAll(TeamMembersRequest request)
        {
            return Call<TeamMembersRequest, CollectionResponse<Member>>(request);
        }
    }
}