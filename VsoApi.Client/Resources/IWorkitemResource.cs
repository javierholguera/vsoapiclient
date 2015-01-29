
namespace VsoApi.Client.Resources
{
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IWorkitemResource
    {
        ListResponse<Workitem> GetAll(WorkitemListRequest request);
        Workitem Get(WorkitemRequest request);
        Workitem Patch(WorkitemCreateRequest request);
        Workitem Patch(WorkitemUpdateRequest request);
    }
}
