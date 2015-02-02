
namespace VsoApi.Client.Resources
{
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IWqilResource
    {
        WiqlFlatQueryResponse Post(WqilFlatRequest request);
    }
}
