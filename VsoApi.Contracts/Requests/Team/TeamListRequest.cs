namespace VsoApi.Contracts.Requests.Team
{
    using System;
    using RestSharp;
    
    /// <summary>
    /// This is a exception to other requests, the project name is not placed after the collection name
    /// </summary>
    public class TeamListRequest : VsoRequest
    {
        public TeamListRequest(string project) : base(string.Empty)
        {
            if (project == null)
                throw new ArgumentNullException("project");
            if (string.IsNullOrWhiteSpace(project))
                throw new ArgumentException("The project cannot be empty");
            
            Project = project;
        }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        public string Project { get; private set; }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            restRequest.AddUrlSegment("project", Project);
        }
    }
}