namespace VsoApi.MsAgile.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using VsoApi.Client;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.WIT;

    public interface ITeamCollection
    {
        IEnumerable<UserStory> GetUserStories(string queryName);
        IEnumerable<UserStory> GetUserStories(Query query);
        IEnumerable<UserStory> GetUserStories(Guid queryId);

        IEnumerable<BaseEntity> GetWorkItems(string query, string project = null);
        IEnumerable<BaseEntity> GetWorkItems(Query query);
        IEnumerable<BaseEntity> GetWorkItems(Guid queryId);
    }

    public class TeamCollection : ITeamCollection
    {
        private VsoClient _client;

        public TeamCollection(ConnectionParameters connectionParameters)
        {
            if (connectionParameters == null)
                throw new ArgumentNullException("connectionParameters");

            _client = new VsoClient(connectionParameters.Url, connectionParameters.UserName, connectionParameters.Password);
        }

        public IEnumerable<UserStory> GetUserStories(string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserStory> GetUserStories(Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserStory> GetUserStories(Guid queryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseEntity> GetWorkItems(string query, string project = null)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Unable to get work items from an empty query", query);

            WiqlQueryResponse queryResult = _client.WiqlResources.Post(new WiqlRequest(project ?? string.Empty, query));
            if (queryResult.QueryType != QueryType.Flat)
                throw new NotSupportedException("Non flat queries are not supported yet");

            CollectionResponse<WorkItem> workItemsResponse = _client.WorkItemResources.GetAll(new WorkItemListRequest(
                queryResult.WorkItems.Select(wi => wi.Id).ToList(),
                null,
                queryResult.Columns.Select(col => col.ReferenceName).ToList()));

            return workItemsResponse.Value.Select(wi =>
            {
                if (wi.Fields.SystemWorkItemType != "User Story")
                    throw new NotSupportedException("Only User stories can be retrieved");
                return Mapper.Map<WorkItem, UserStory>(wi);
            }).ToList();
        }

        public IEnumerable<BaseEntity> GetWorkItems(Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseEntity> GetWorkItems(Guid queryId)
        {
            throw new NotImplementedException();
        }
    }

    public class ConnectionParameters
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Uri Url { get; set; }
    }
}