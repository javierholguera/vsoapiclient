namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using RestSharp;

    public class WiqlRequest : VsoRequest
    {
        public WiqlRequest(string query)
            : this(string.Empty, query)
        {
        }

        public WiqlRequest(string project, string query)
            : base(project)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Query content is mandatory to request a flat WIQL", "query");

            RequestBody = new QueryBody { Query = query };
        }

        private QueryBody RequestBody { get; set; }

        protected override Method Method
        {
            get { return Method.POST; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            // Workaround to set the content type and avoid getting it overriden when setting the body directly
            // http://stackoverflow.com/a/9436436/3086378
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(RequestBody), ParameterType.RequestBody);
        }

        private class QueryBody
        {
            public string Query { get; set; }
        }
    }
}