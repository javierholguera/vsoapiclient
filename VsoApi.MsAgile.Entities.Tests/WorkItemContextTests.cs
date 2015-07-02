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

        [Test]
        public void Get_All_Tasks_From_Personal_As_Of_Recent_Date()
        {
            List<Task> results = _context.Tasks
                .Where(u => u.IterationPath == "Personal")
                .AsOf(new DateTime(2015, 04, 25, 23, 14, 00))
                .ToList();
            Assert.That(results.Count, Is.EqualTo(26));
            Assert.That(
                results.Count(t => t.AssignedTo == "Javier Holguera <jholguerablanco@hotmail.com>"),
                Is.EqualTo(3));
            Assert.That(
                results.Count(t => t.State == "Closed"),
                Is.EqualTo(4));
            Assert.That(
                results.Single(r => r.Id == 90).Description,
                Is.EqualTo("Enable style cop in the solution to make code more readable"));
        }

        [Test]
        public void Get_All_Tasks_From_Personal_As_Of_Old_Date()
        {
            List<Task> results = _context.Tasks
                .Where(u => u.IterationPath == "Personal")
                .AsOf(new DateTime(2015, 03, 13))
                .ToList();
            Assert.That(results.Count, Is.EqualTo(24));
            Assert.That(
                results.Count(t => t.AssignedTo == "Javier Holguera <jholguerablanco@hotmail.com>"),
                Is.EqualTo(1));
            Assert.That(
                results.Count(t => t.State == "Closed"),
                Is.EqualTo(4));

            // This description was changed on April, 20th. So if the AsOF operator works,
            // we should get the previous values, which was null.
            Assert.That(results.Single(r => r.Id == 90).Description, Is.Null);
        }

        [Test]
        public void Get_All_Bugs_From_Personal()
        {
            List<Bug> results = _context.Bugs.Where(u => u.IterationPath == "Personal").ToList();
            Assert.That(results.Count, Is.EqualTo(2));
            Assert.IsTrue(results.Any(b => b.AssignedTo == "Javier Holguera <jholguerablanco@hotmail.com>"));
        }

        [Test]
        public void Get_All_Personal_Iterations_To_Two_Depth()
        {
            List<Iteration> results = _context.Iterations.Where(u => u.Project == "Personal" && u.Depth == 2).ToList();
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First().Children, Is.Not.Empty);
        }

        [Test]
        public void Get_Iteration_Info()
        {
            List<Iteration> results = _context.Iterations.Where(u => u.Project == "Personal" && u.Name == "Iteration 1").ToList();
            Assert.That(results.Count,Is.EqualTo(1));
            Assert.That(results.Single().Name, Is.EqualTo("Iteration 1"));
            Assert.AreEqual(
                new DateTimeOffset(new DateTime(2015, 03, 30, 0, 0, 0, DateTimeKind.Utc)), results.Single().StartDate);
            Assert.AreEqual(
                new DateTimeOffset(new DateTime(2015, 04, 06, 0, 0, 0, DateTimeKind.Utc)), results.Single().FinishDate);
        }
    }

    internal static class Config
    {
        internal static Uri BaseUri = new Uri("https://javierholguera.visualstudio.com/DefaultCollection");
        internal static string Username = "javierh";
        internal static string Password = "1Vso#client1";
    }
}