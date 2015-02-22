
namespace VsoApi.Client.Resources
{
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IWorkItemTypeResource
    {
        CollectionResponse<WorkItemType> GetAll(WorkItemTypeListRequest request);
        WorkItemType Get(WorkItemTypeRequest request);
    }
}
