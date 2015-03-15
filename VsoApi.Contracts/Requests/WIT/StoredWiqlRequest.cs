namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using RestSharp;

    public class StoredWiqlRequest : VsoRequest
    {
        public StoredWiqlRequest(string project, Guid queryId) : base(project)
        {
            if (queryId == Guid.Empty)
                throw new ArgumentException("A stored query cannot be requested with an empty query ID");

            QueryId = queryId;
        }

        public StoredWiqlRequest(Guid queryId) : this(string.Empty, queryId)
        {
        }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        public Guid QueryId { get; private set; }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{id}";

            restRequest.AddUrlSegment("id", QueryId.ToString());
        }
    }
}