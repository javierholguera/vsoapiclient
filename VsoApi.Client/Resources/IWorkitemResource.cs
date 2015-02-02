
namespace VsoApi.Client.Resources
{
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IWorkItemResource
    {
        ListResponse<WorkItem> GetAll(WorkItemListRequest request);
        WorkItem Get(WorkItemRequest request);
        WorkItem Patch(WorkItemCreateRequest request);
        WorkItem Patch(WorkItemUpdateRequest request);
    }
}
