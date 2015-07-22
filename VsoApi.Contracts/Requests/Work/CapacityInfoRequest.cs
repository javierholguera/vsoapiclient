using System;
using RestSharp;

namespace VsoApi.Contracts.Requests.Work
{
    public class CapacityInfoRequest : VsoRequest
    {
        public CapacityInfoRequest(string project, string team, Guid iterationId)
            : base(project)
        {
            if (team == null)
                throw new ArgumentNullException("team");
            
            if (string.IsNullOrWhiteSpace(team))
                throw new ArgumentException("Unable to request team days off without the team name");
            
            Team = team;
            Iteration = iterationId;
        }

        public string Team { get; private set; }
        public Guid Iteration { get; private set; }

        protected override string ApiVersion
        {
            get { return "2.0-preview.1"; }
        }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            restRequest.AddUrlSegment("team", Team);
            restRequest.AddUrlSegment("iterationid", Iteration.ToString());
        }
    }
}