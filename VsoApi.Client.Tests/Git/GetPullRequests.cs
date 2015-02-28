﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VsoApi.Client.Tests.Git
{
    using System.Linq;
    using VsoApi.Contracts.Requests.Git;
    using VsoApi.Contracts.Responses;
    using VsoApi.Contracts.Responses.Git;

    [TestClass]
    public class GetPullRequests
    {
        [Ignore]
        [TestMethod]
        public void GetListOfPullRequests()
        {
            var client = new VsoClient(
                new Uri("https://marketinvoice.visualstudio.com/defaultCollection"),
                "javiermi",
                ""); // set this

            // Id for the platform repository 
            CollectionResponse<RepositoryResponse> result = client.PullRequestResources.Get(
                new PullRequestListRequest { Repository = "ba91c08c-cbcc-4d55-83fe-0da8e63bc9e1" });

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value.Any());
        }
    }
}