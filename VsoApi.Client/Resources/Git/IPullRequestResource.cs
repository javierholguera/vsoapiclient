
namespace VsoApi.Client.Resources.Git
{
    using VsoApi.Contracts.Requests.Git;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Git;

    public interface IPullRequestResource
    {
        CollectionResponse<RepositoryResponse> Get(PullRequestListRequest request);
    }
}
