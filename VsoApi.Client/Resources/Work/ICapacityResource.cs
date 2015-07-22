using VsoApi.Contracts.Requests.Work;
using VsoApi.Contracts.Responses;
using VsoApi.Contracts.Responses.Work;

namespace VsoApi.Client.Resources.Work
{
    public interface ICapacityResource
    {
        CollectionResponse<TeamMemberCapacity> GetAll(CapacityInfoRequest request);
        TeamMemberCapacity Get(TeamMemberCapacityRequest request);
    }
}