
namespace VsoApi.Client.Resources.Git
{
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Git;

    public interface IRepositoryResource
    {
        CollectionResponse<Repository> Get(EmptyRequest request);
    }
}
