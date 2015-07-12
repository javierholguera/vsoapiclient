namespace VsoApi.Client.Resources.Teams
{
    using VsoApi.Contracts.Requests.Team;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Team;

    public interface ITeamResource
    {
        CollectionResponse<Team> GetAll(TeamListRequest request);
    }
}