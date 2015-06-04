namespace VsoApi.Client.Tests.WIT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses.WIT;

    [TestClass]
    public class GetClassificationNodeTests
    {
        [TestMethod]
        public void GetIterations_NoDepth()
        {
            var client = new VsoClient();
            ClassificationNodeResponse result = client.ClassificationNodeResources.Get(
                new ClassificationNodeListRequest("Personal", ClassificationNodeType.Iteration));

            Assert.IsTrue(result.HasChildren);
            Assert.AreEqual("Personal", result.Name);
            Assert.AreEqual(ClassificationNodeType.Iteration, result.StructureType);
            Assert.AreEqual(0, result.Children.Count());
            Assert.IsTrue(result.Url != null);
        }

        [TestMethod]
        public void GetIterations_WithDepth()
        {
            var client = new VsoClient();
            ClassificationNodeResponse result = client.ClassificationNodeResources.Get(
                new ClassificationNodeListRequest("Personal", ClassificationNodeType.Iteration, 2));

            Assert.IsTrue(result.HasChildren);
            Assert.AreEqual("Personal", result.Name);
            Assert.AreEqual(ClassificationNodeType.Iteration, result.StructureType);
            Assert.AreNotEqual(null, result.Children);
            Assert.IsTrue(result.Url != null);

            List<ClassificationNodeResponse> children = result.Children.ToList();
            for (int i = 0; i < children.Count; i++) {

                ClassificationNodeResponse iteration = children[i];
                Assert.IsFalse(iteration.HasChildren);
                Assert.AreEqual("Iteration " + (i + 1), iteration.Name);
                Assert.AreEqual(ClassificationNodeType.Iteration, iteration.StructureType);
                Assert.AreEqual(0, iteration.Children.Count());
                Assert.IsTrue(iteration.Url != null);
            }
        }

        [TestMethod]
        public void GetAreas_NoDepth()
        {
            var client = new VsoClient();
            ClassificationNodeResponse result = client.ClassificationNodeResources.Get(
                new ClassificationNodeListRequest("Personal", ClassificationNodeType.Area));

            Assert.IsTrue(result.HasChildren);
            Assert.AreEqual("Personal", result.Name);
            Assert.AreEqual(ClassificationNodeType.Area, result.StructureType);
            Assert.AreEqual(0, result.Children.Count());
            Assert.IsTrue(result.Url != null);
        }

        [TestMethod]
        public void GetAreas_WithDepth()
        {
            var client = new VsoClient();
            ClassificationNodeResponse result = client.ClassificationNodeResources.Get(
                new ClassificationNodeListRequest("Personal", ClassificationNodeType.Area, 2));

            Assert.IsTrue(result.HasChildren);
            Assert.AreEqual("Personal", result.Name);
            Assert.AreEqual(ClassificationNodeType.Area, result.StructureType);
            Assert.AreNotEqual(null, result.Children);
            Assert.IsTrue(result.Url != null);

            List<ClassificationNodeResponse> children = result.Children.ToList();

            var firstSubarea = children.Single(a => a.Name == "TopReformas");
            Assert.IsFalse(firstSubarea.HasChildren);
            Assert.AreEqual(ClassificationNodeType.Area, firstSubarea.StructureType);
            Assert.AreEqual(0, firstSubarea.Children.Count());
            Assert.IsTrue(firstSubarea.Url != null);

            var secondSubarea = children.Single(a => a.Name == "VsoClient");
            Assert.IsFalse(secondSubarea.HasChildren);
            Assert.AreEqual("VsoClient", secondSubarea.Name);
            Assert.AreEqual(ClassificationNodeType.Area, secondSubarea.StructureType);
            Assert.AreEqual(0, secondSubarea.Children.Count());
            Assert.IsTrue(secondSubarea.Url != null);
        }

        [TestMethod]
        public void GetSpecificIteration()
        {
            var client = new VsoClient();
            IterationNodeResponse result = client.ClassificationNodeResources.Get(
                new IterationRequest("Personal", "Iteration 1"));

            Assert.IsFalse(result.HasChildren);
            Assert.AreEqual("Iteration 1", result.Name);
            Assert.AreEqual(ClassificationNodeType.Iteration, result.StructureType);
            Assert.AreEqual(0, result.Children.Count());
            Assert.IsTrue(result.Url != null);
            Assert.IsNotNull(result.Attributes);
            Assert.AreEqual(
                new DateTimeOffset(new DateTime(2015, 03, 30, 0, 0, 0, DateTimeKind.Utc)), result.Attributes.StartDate);
            Assert.AreEqual(
                new DateTimeOffset(new DateTime(2015, 04, 06, 0, 0, 0, DateTimeKind.Utc)), result.Attributes.FinishDate);
        }
    }
}