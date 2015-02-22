namespace VsoApi.Client.Resources
{
    using System;
    using System.Collections.Generic;
    using VsoApi.Contracts.Models;

    public class WorkItemFieldInfo : VsoEntity
    {
        public string Name { get; set; }
        public string ReferenceName { get; set; }
        public string Type { get; set; }
        public bool ReadOnly { get; set; }
        public IEnumerable<SupportedOperation> SupportedOperations { get; set; }
        public Uri Url { get; set; }
    }

    public class SupportedOperation
    {
        public string ReferenceName { get; set; }
        public string Name { get; set; }
    }
}