
namespace VsoApi.Client.Resources.WIT
{
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.WIT;

    public interface IFieldResource
    {
        CollectionResponse<WorkItemFieldInfo> GetAll(EmptyRequest request);
        WorkItemFieldInfo Get(FieldListRequest request);
    }
}
