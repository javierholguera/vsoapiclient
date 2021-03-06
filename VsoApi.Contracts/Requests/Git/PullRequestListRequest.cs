﻿

namespace VsoApi.Contracts.Requests.Git
{
    using System;
    using RestSharp;

    public class PullRequestListRequest : VsoRequest
    {
        public PullRequestListRequest(string repository) : this(repository, PullRequestStatus.Active)
        {
        }

        public PullRequestListRequest(string repository, PullRequestStatus status) : base(string.Empty)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            if (string.IsNullOrWhiteSpace(repository))
                throw new ArgumentException("Repository name is mandatory to request a list of pull requests", "repository");

            Repository = repository;
            Status = status;
        }

        private string Repository { get; set; }

        private PullRequestStatus Status { get; set; }

        protected override string ApiVersion
        {
            get { return "1.0-preview.1"; }
        }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            restRequest.Resource += "/{repository}/pullrequests";
            restRequest.AddUrlSegment("repository", Repository);
            restRequest.AddQueryParameter("status", Status.ToString());
        }
    }

    public enum PullRequestStatus
    {
        Active,
        Abandoned,
        Completed
    }
}
