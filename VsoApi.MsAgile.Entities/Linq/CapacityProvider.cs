

namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using IQToolkit;
    using VsoApi.Client;
    using VsoApi.Contracts.Requests.Work;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Work;

    public class CapacityProvider : QueryProvider
    {
        private readonly VsoClient _client;

        public CapacityProvider(VsoClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            _client = client;
        }

        public override string GetQueryText(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            return Translate(expression).ToString();
        }

        public override object Execute(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            // TODO: Support queries with project name

            // 1. Re-evaluates the expression to access closure variables
            expression = PartialEvaluator.Eval(expression);

            // 2. Translate the expression tree to classification node request
            CapacityInfoRequest request = Translate(expression);

            // 3. Get results for the query
            CollectionResponse<TeamMemberCapacity> capacityInformation = _client.CapacityResources.GetAll(request);
            TeamDaysOffResponse teamDaysOffInformation = _client.TeamDaysOffResources.Get(request);
            TeamCapacityResult result = new TeamCapacityResult(capacityInformation, teamDaysOffInformation);

            // 4. Convert the iteration information into a entity reader that can be iterated
            return Activator.CreateInstance(
                typeof(BaseEntityReader<TeamCapacityResult, TeamCapacity>),
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new object[] { new [] { capacityInformation } },
                null);
        }

        private static CapacityInfoRequest Translate(Expression expression)
        {
            return new CapacityTranslator().Translate(expression);
        }
    }

    internal class TeamCapacityResult
    {
        public TeamCapacityResult()
        {
        }

        public TeamCapacityResult(CollectionResponse<TeamMemberCapacity> memberCapacities, TeamDaysOffResponse daysOffInfo)
        {
            if (memberCapacities == null)
                throw new ArgumentNullException("memberCapacities");
            if (daysOffInfo == null)
                throw new ArgumentNullException("DaysOffInfo");

            MemberCapacities = memberCapacities;
            DaysOffInfo = daysOffInfo;
        }

        public CollectionResponse<TeamMemberCapacity> MemberCapacities { get; private set; }
        public TeamDaysOffResponse DaysOffInfo { get; private set; }
    }
}