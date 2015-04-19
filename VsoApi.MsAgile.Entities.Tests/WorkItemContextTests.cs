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
        private WorkItemContext _context;

        [SetUp]
        public void SetUp()
        {
            Mapping.Configure();

            VsoClient client = new VsoClient(Config.BaseUri, Config.Username, Config.Password);
            _context = new WorkItemContext(client);
        }

        [Test]
        public void Get_UsersStories_From_Personal()
        {
            List<UserStory> results = _context.UserStories
                .Where(u => u.IterationPath == "Personal" && u.StoryPoints == 2m)
                .ToList();
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.Single().Id, Is.EqualTo(121));
            Assert.That(results.Single().AssignedTo, Is.EqualTo("Javier Holguera <jholguerablanco@hotmail.com>"));
        }

        [Test]
        public void Get_UsersStories_From_Personal_with_contextual_variable_access()
        {
            // With a constant value we wouldn't take this scenario
            const string iterationPath = "Personal";
            List<UserStory> results = _context.UserStories
                .Where(u => u.IterationPath == iterationPath && u.StoryPoints == 2m)
                .ToList();
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.Single().Id, Is.EqualTo(121));
            Assert.That(results.Single().AssignedTo, Is.EqualTo("Javier Holguera <jholguerablanco@hotmail.com>"));
        }

        [Test]
        public void Get_All_Tasks_From_Personal()
        {
            List<Task> results = _context.Tasks.Where(u => u.IterationPath == "Personal").ToList();
            Assert.That(results.Count, Is.EqualTo(26));
            Assert.That(
                results.Count(t => t.AssignedTo == "Javier Holguera <jholguerablanco@hotmail.com>"),
                Is.EqualTo(3));
            Assert.That(
                results.Count(t => t.State == "Closed"),
                Is.EqualTo(4));
        }
    }

    internal static class Config
    {
        internal static Uri BaseUri = new Uri("https://javierholguera.visualstudio.com/DefaultCollection");
        internal static string Username = "javierh";
        internal static string Password = "1Vso#client1";
    }
}