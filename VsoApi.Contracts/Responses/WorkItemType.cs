namespace VsoApi.Contracts.Responses
{
    using System;
    using System.Collections.Generic;
    using VsoApi.Contracts.Models;

    public class WorkItemType : VsoEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string XmlForm { get; set; }
        public IEnumerable<WorkItemField> FieldInstances { get; set; }
        public WorkItemWorkflow Transitions { get; set; }
        public Uri Url { get; set; }
    }
}