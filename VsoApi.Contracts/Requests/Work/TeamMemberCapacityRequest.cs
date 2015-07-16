using System;
using RestSharp;

namespace VsoApi.Contracts.Requests.Work
{
    public class TeamMemberCapacityRequest : CapacityInfoRequest
    {
        public TeamMemberCapacityRequest(string project, string team, Guid iterationId, Guid memberId)
            : base(project, team, iterationId)
        {
            MemberId = memberId;
        }

        public Guid MemberId { get; private set; }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            base.CompleteRequest(restRequest);

            restRequest.Resource += "/{member}";
            restRequest.AddUrlSegment("member", MemberId.ToString());
        }
    }
}