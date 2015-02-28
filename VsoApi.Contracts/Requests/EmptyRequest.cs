namespace VsoApi.Contracts.Requests
{
    using RestSharp;

    public class EmptyRequest : VsoRequest
    {
        public EmptyRequest() : base(string.Empty)
        {
        }

        public EmptyRequest(string teamProject)
            : base(teamProject)
        {
        }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
        }
    }
}