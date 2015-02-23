namespace VsoApi.Client.Resources.Git
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Git;

    public class RepositoryResource : BaseResource, IRepositoryResource
    {
        public RepositoryResource(IRestClient requestClient) : base(requestClient)
        {
        }

        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/git/repositories", UriKind.Relative); }
        }

        public CollectionResponse<Repository> Get(EmptyRequest request)
        {
            return Call<EmptyRequest, CollectionResponse<Repository>>(request);
        }
    }
}