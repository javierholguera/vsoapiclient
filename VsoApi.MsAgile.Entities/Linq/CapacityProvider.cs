namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using IQToolkit;
    using VsoApi.Client;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses.WIT;

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
            SprintCapacityRequest request = Translate(expression);

            // 3. Get results for the query
            SprintCapacityResponse capacityInformation = _client.CapacityResources.Get(request);
            
            // 4. Convert the iteration information into a entity reader that can be iterated
            return Activator.CreateInstance(
                typeof(BaseEntityReader<SprintCapacityResponse, Capacity>),
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new object[] { new [] { capacityInformation } },
                null);
        }

        private static SprintCapacityRequest Translate(Expression expression)
        {
            return new CapacityTranslator().Translate(expression);
        }
    }
}