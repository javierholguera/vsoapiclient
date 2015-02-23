
namespace VsoApi.Client.Resources.WIT
{
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;

    public interface IWorkItemResource
    {
        CollectionResponse<WorkItem> GetAll(WorkItemListRequest request);
        WorkItem Get(WorkItemRequest request);
        WorkItem Patch(WorkItemCreateRequest request);
        WorkItem Patch(WorkItemUpdateRequest request);
    }
}
