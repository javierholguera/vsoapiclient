namespace VsoApi.Backend.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using VsoApi.Backend.Contracts;
    using VsoApi.Backend.DataAccess;
    using VsoApi.Backend.DomainModel;

    [RoutePrefix("_apis/wit/capacity")]
    public class CapacityController : ApiController
    {
        private readonly IVsoApiContext _context;

        public CapacityController()
        {
            _context = new VsoApiContext();
        }

        // GET Capacity/SprintName
        [Route("{sprintName}")]
        [HttpGet]
        public HttpResponseMessage GetSprintCapacity(string sprintName)
        {
            Sprint sprint = _context.Sprints.SingleOrDefault(s => s.Name == sprintName);
            if (sprint == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no sprint with name " + sprintName);

            SprintInfo info = new SprintInfo {
                Name = sprint.Name,
                SupportDays = sprint.SupportDays,
                CapacityInfos = sprint.MemberCapacities.Select(m => new MemberCapacityInfo {
                    TeamMemberName = m.TeamMember.Name,
                    Capacity = m.Capacity
                })
            };

            return Request.CreateResponse(HttpStatusCode.Accepted, info);
        }

        // POST Capacity/SprintName
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] SprintInfo sprintInfo)
        {
            Sprint storedSprint = _context.Sprints.SingleOrDefault(s => s.Name == sprintInfo.Name);
            if (storedSprint == null) {
                storedSprint = new Sprint {Name = sprintInfo.Name};
                _context.Sprints.Add(storedSprint);
            }

            // Delete all member capacities and recreate them
            storedSprint.MemberCapacities.ToList().ForEach(m => _context.MemberCapacities.Remove(m));

            foreach (MemberCapacityInfo capacityInfo in sprintInfo.CapacityInfos) {
                var storedUser = _context.TeamMembers.SingleOrDefault(member => member.Name == capacityInfo.TeamMemberName);
                if (storedUser == null) {
                    storedUser = new TeamMember { Name = capacityInfo.TeamMemberName };
                    _context.TeamMembers.Add(storedUser);
                }
                storedSprint.MemberCapacities.Add(new MemberCapacity {
                    TeamMember = storedUser,
                    Capacity = capacityInfo.Capacity
                });
            }

            _context.Save();

            SprintInfo result = new SprintInfo {
                Name = storedSprint.Name,
                CapacityInfos = storedSprint.MemberCapacities.Select(m => new MemberCapacityInfo {
                    TeamMemberName = m.TeamMember.Name,
                    Capacity = m.Capacity
                })
            };

            return Request.CreateResponse(HttpStatusCode.Accepted, result);
        }
    }
}