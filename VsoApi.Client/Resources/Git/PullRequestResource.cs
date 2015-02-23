namespace VsoApi.Client.Resources.Git
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests.Git;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Git;

    public class PullRequestResource : BaseResource, IPullRequestResource
    {
        public PullRequestResource(IRestClient requestClient) : base(requestClient)
        {
        }

        public CollectionResponse<RepositoryResponse> Get(PullRequestListRequest request)
        {
            return Call<PullRequestListRequest, CollectionResponse<RepositoryResponse>>(request);
        }

        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/git/repositories", UriKind.Relative); }
        }
    }
}