
using VsoApi.Contracts.Requests.Work;
using VsoApi.Contracts.Responses.Work;

namespace VsoApi.Client.Resources.Work
{
    public interface ITeamDaysOffResource
    {
        TeamDaysOffResponse Get(CapacityInfoRequest request);
    }
}