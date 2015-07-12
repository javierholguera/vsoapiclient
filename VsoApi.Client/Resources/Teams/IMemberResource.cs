namespace VsoApi.Client.Resources.Teams
{
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Requests.Team;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Team;

    public interface IMemberResource
    {
        CollectionResponse<Member> GetAll(TeamMembersRequest request);
    }
}