namespace VsoApi.Contracts.Requests
{
    using System;
    using RestSharp;

    public abstract class VsoRequest
    {
        protected VsoRequest(string project)
        {
            if (project == null)
                throw new ArgumentNullException("project");

            Project = project;
        }

        private string Project { set; get; }

        // Paramater "api-version"
        protected virtual string ApiVersion
        {
            get { return "1.0"; }
        }

        protected abstract Method Method { get; }

        public IRestRequest GetRestRequest(Uri resourceUri)
        {
            IRestRequest restRequest;
            if (string.IsNullOrWhiteSpace(Project) == false) {
                restRequest = new RestRequest(new Uri("/{project}" + resourceUri, UriKind.Relative), Method);
                restRequest.AddUrlSegment("project", Project);
            } else {
                restRequest = new RestRequest(resourceUri, Method);
            }

            restRequest.AddQueryParameter("api-version", ApiVersion);
            CompleteRequest(restRequest);
            return restRequest;
        }

        protected abstract void CompleteRequest(IRestRequest restRequest);
    }
}