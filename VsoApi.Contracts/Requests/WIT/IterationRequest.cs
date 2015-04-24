﻿namespace VsoApi.Contracts.Requests.WIT
{
    public class IterationRequest : ClassificationNodeListRequest
    {
        public IterationRequest(string project, string iterationName) :
            base(project, ClassificationNodeType.Iteration, iterationName, 1)
        {
        }

        public IterationRequest(string project, string iterationName, int depth) : 
            base(project, ClassificationNodeType.Iteration, iterationName, depth)
        {
        }
    }
}