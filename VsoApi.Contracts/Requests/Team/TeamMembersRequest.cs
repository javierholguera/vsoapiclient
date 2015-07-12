namespace VsoApi.Contracts.Requests.Team
{
    using System;
    using RestSharp;

    public class TeamMembersRequest : VsoRequest
    {
        public TeamMembersRequest(string project, string teamName) : base(string.Empty)
        {
            if (teamName == null)
                throw new ArgumentNullException("teamName");
            if (string.IsNullOrWhiteSpace(teamName))
                throw new ArgumentException("The team name cannot be empty");

            // This is a exception to other requests, the project name is not placed after the collection name
            Project = project;
            TeamName = teamName;
        }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        public string TeamName { get; private set; }

        public string Project { get; private set; }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            restRequest.AddUrlSegment("project", Project);
            restRequest.AddUrlSegment("team", TeamName);
        }
    }
}