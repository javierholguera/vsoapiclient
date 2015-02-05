﻿
namespace VsoApi.Client.Resources
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IWorkItemTypeResource
    {
        ListResponse<WorkItemType> GetAll(WorkItemTypeListRequest request);
        WorkItemType Get(WorkItemTypeRequest request);
    }

    public class WorkItemTypeResource : IWorkItemTypeResource
    {
        private readonly IRestClient _client;

        public WorkItemTypeResource(IRestClient client)
        {
            _client = client;
        }

        private string QueryResourceUri
        {
            get { return "{project}/_apis/wit/workitemtypes"; }
        }

        public ListResponse<WorkItemType> GetAll(WorkItemTypeListRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<ListResponse<WorkItemType>>(restResponse.Content);
        }

        public WorkItemType Get(WorkItemTypeRequest request)
        {
            IRestRequest restRequest = request.GetRestRequest(QueryResourceUri);
            IRestResponse restResponse = _client.Execute(restRequest);

            return JsonConvert.DeserializeObject<WorkItemType>(restResponse.Content);
        }
    }

    public class WorkItemType : VsoEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string XmlForm { get; set; }
        public IEnumerable<WorkItemField> FieldInstances { get; set; }
        public WorkItemWorkflow Transitions { get; set; }
        public Uri Url { get; set; }
    }

    public class WorkItemWorkflow
    {
        [JsonProperty(PropertyName = "")]
        public IEnumerable<Transition> Initial { get; set; }

        [JsonProperty(PropertyName = "To Do")]
        public IEnumerable<Transition> ToDo { get; set; }

        public IEnumerable<Transition> InProgress { get; set; }
        public IEnumerable<Transition> Done { get; set; }
        public IEnumerable<Transition> Removed { get; set; }
    }

    public class Transition
    {
        public string To { get; set; }
        public IEnumerable<string> Actions { get; set; }
    }

    public class WorkItemField
    {
        public string ReferenceName { get; set; }
        public string Name { get; set; }
        public Uri Url { get; set; }
    }
}