
namespace VsoApi.Client.Resources
{
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IWiqlResource
    {
        WiqlFlatQueryResponse Post(WiqlFlatRequest request);
    }
}
