namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using IQToolkit;
    using VsoApi.Client;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.WIT;

    public class WorkItemProvider : QueryProvider
    {
        private readonly VsoClient _client;

        public WorkItemProvider(VsoClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            _client = client;
        }

        public override string GetQueryText(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            return Translate(expression);
        }

        public override object Execute(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            // TODO: Support queries with project name

            // 1. Re-evaluates the expression to access closure variables
            expression = PartialEvaluator.Eval(expression);

            // 2. Translate the expression tree to a WIQL query
            string query = Translate(expression);

            // 3. Get results for the query
            WiqlQueryResponse queryResults = _client.WiqlResources.Post(new WiqlRequest(query));

            // TODO: Support queries that are hierarchical
            // 4. Get actual workitems information
            uint[] workItemIds = queryResults.WorkItems.Select(wi => wi.Id).ToArray();
            CollectionResponse<WorkItem> workitems = _client.WorkItemResources.GetAll(new WorkItemListRequest(workItemIds));

            // 5. Convert the workitem information into a entity reader that can be iterated
            Type elementType = TypeHelper.GetElementType(expression.Type);
            return Activator.CreateInstance(
                typeof(BaseEntityReader<>).MakeGenericType(elementType),
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new object[] { workitems },
                null);
        }

        private static string Translate(Expression expression)
        {
            return new QueryTranslator().Translate(expression);
        }
    }
}