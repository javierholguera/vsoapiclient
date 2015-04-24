namespace VsoApi.Client.Resources.WIT
{
    using System;
    using RestSharp;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses.WIT;

    public class ClassificationNodeResource : BaseResource, IClassificationNodeResource
    {
        public ClassificationNodeResource(IRestClient requestClient) : base(requestClient)
        {
        }

        protected override Uri ResourceUri
        {
            get { return new Uri("/_apis/wit/classificationnodes/{nodetype}", UriKind.Relative); }
        }

        public ClassificationNodeResponse Get(ClassificationNodeListRequest request)
        {
            return Call<ClassificationNodeListRequest, ClassificationNodeResponse>(request);
        }

        public IterationNodeResponse Get(IterationRequest request)
        {
            return Call<IterationRequest, IterationNodeResponse>(request);
        }
    }
}