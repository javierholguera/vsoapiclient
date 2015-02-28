
namespace VsoApi.Client.Resources.WIT
{
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.WIT;

    public interface IWorkItemTypeResource
    {
        CollectionResponse<WorkItemType> GetAll(EmptyRequest request);
        WorkItemType Get(WorkItemTypeRequest request);
    }
}
