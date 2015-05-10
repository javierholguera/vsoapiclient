namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using RestSharp;
    using VsoApi.Contracts.Responses.WIT;

    public class SetSprintCapacityRequest : VsoRequest
    {
        public SetSprintCapacityRequest(string project, string iterationPath, ICollection<CapacityInfo> capacityInfos) 
            : base(project)
        {
            if (iterationPath == null)
                throw new ArgumentNullException("iterationPath");
            if (capacityInfos == null)
                throw new ArgumentNullException("capacityInfos");
            if (string.IsNullOrWhiteSpace(iterationPath))
                throw new ArgumentException("A sprint capacity cannot be set for a sprint with an empty iteration path");

            Name = iterationPath;
            CapacityInfos = capacityInfos;
        }

        protected override Method Method
        {
            get { return Method.POST; }
        }

        public string Name { get; private set; }
        public ICollection<CapacityInfo> CapacityInfos { get; private set; }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(this);
        }
    }
}