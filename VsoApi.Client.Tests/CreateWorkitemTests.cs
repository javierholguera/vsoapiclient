

namespace VsoApi.Client.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VsoApi.Contracts.Models;
    using VsoApi.Contracts.Requests;
    using Field = VsoApi.Contracts.Requests.WorkitemCreateRequest.FieldEntry;

    [TestClass]
    public class CreateWorkitemTests
    {
        [TestMethod]
        public void CreateWorkitemWithMinimumParameters()
        {
            VsoClient client = new VsoClient();
            var request = new WorkitemCreateRequest {
                Project = "TopReformas",
                WorkItemTypeName = "Task",
                Body = new List<Field> {
                    new Field { Op = "add", Path = "/fields/" + WorkitemFields.AreaPathField, Value = "TopReformas" },
                    new Field { Op = "add", Path = "/fields/" + WorkitemFields.IterationPathField, Value = "TopReformas" },
                    new Field { Op = "add", Path = "/fields/" + WorkitemFields.TitleField, Value = "Created from API Client" },
                }
            };

            Workitem result = client.WorkitemResources.Patch(request);
            Assert.IsNotNull(result);
        }
    }
}
