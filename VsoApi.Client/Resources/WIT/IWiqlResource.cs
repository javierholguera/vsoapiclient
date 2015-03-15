
namespace VsoApi.Client.Resources.WIT
{
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses.WIT;

    public interface IWiqlResource
    {
        WiqlQueryResponse Post(WiqlRequest request);
        WiqlQueryResponse Post(StoredWiqlRequest request);
    }
}
