using System;
using RestSharp;
using VsoApi.Contracts.Requests;
using VsoApi.Contracts.Requests.Work;
using VsoApi.Contracts.Responses.Work;

namespace VsoApi.Client.Resources.Work
{
    public class TeamDaysOffResource : BaseResource, ITeamDaysOffResource 
    {
        public TeamDaysOffResource(IRestClient requestClient) : base(requestClient)
        {
        }

        protected override Uri ResourceUri
        {
            get { return new Uri("/{team}/_apis/work/teamsettings/iterations/{iterationid}/teamdaysoff", UriKind.Relative); }
        }

        public TeamDaysOffResponse Get(TeamDaysOffRequest request)
        {
            return Call<TeamDaysOffRequest, TeamDaysOffResponse>(request);
        }
    }
}