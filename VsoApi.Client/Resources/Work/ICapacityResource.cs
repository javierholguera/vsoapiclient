using VsoApi.Contracts.Requests.Work;
using VsoApi.Contracts.Responses;
using VsoApi.Contracts.Responses.Work;

namespace VsoApi.Client.Resources.Work
{
    public interface ICapacityResource
    {
        CollectionResponse<TeamMemberCapacity> GetAll(TeamCapacityRequest request);
        TeamMemberCapacity Get(TeamMemberCapacityRequest request);
    }
}