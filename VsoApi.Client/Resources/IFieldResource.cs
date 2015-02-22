
namespace VsoApi.Client.Resources
{
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IFieldResource
    {
        CollectionResponse<WorkItemFieldInfo> GetAll(EmptyRequest request);
        WorkItemFieldInfo Get(FieldListRequest request);
    }
}
