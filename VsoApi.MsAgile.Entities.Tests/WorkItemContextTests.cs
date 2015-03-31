namespace VsoApi.MsAgile.Entities.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using VsoApi.Client;
    using VsoApi.MsAgile.Entities.Linq;
    using VsoApi.MsAgile.Entities.Mappings;

    [TestFixture]
    public class WorkItemContextTests
    {
        [Test]
        public void Get_UsersStories_From_Iteration_44()
        {
            MappingConfiguration.Configure();

            var client = new VsoClient(Config.BaseUri, Config.Username, Config.Password);
            var context = new WorkItemContext(client);
            List<UserStory> results = context.UserStories
                .Where(u => u.IterationPath == "Personal" && u.StoryPoints == 2m)
                .ToList();
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.Single().Id, Is.EqualTo(121));
            Assert.That(results.Single().AssignedTo, Is.EqualTo("Javier Holguera <jholguerablanco@hotmail.com>"));
        }

        [Test]
        public void Get_UsersStories_From_Iteration_44_with_contextual_variable_access()
        {
            MappingConfiguration.Configure();

            var client = new VsoClient(Config.BaseUri, Config.Username, Config.Password);
            var context = new WorkItemContext(client);

            // With a constant value we wouldn't take this scenario
            string iterationPath = "Personal";
            List<UserStory> results = context.UserStories
                .Where(u => u.IterationPath == iterationPath && u.StoryPoints == 2m)
                .ToList();
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.Single().Id, Is.EqualTo(121));
            Assert.That(results.Single().AssignedTo, Is.EqualTo("Javier Holguera <jholguerablanco@hotmail.com>"));
        }
    }

    internal static class Config
    {
        internal static Uri BaseUri = new Uri("https://javierholguera.visualstudio.com/DefaultCollection");
        internal static string Username = "javierh";
        internal static string Password = "1Vso#client1";
    }
}