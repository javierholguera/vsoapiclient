namespace VsoApi.MsAgile.Metrics
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using VsoApi.MsAgile.Entities;
    using VsoApi.MsAgile.Entities.Linq;

    public class BugsInBacklogAsOfSprintEndResult : IMetricResult<int>
    {
        public BugsInBacklogAsOfSprintEndResult(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }
    }

    public class BugsInBacklogAsOfSprintEndMetric : IMetric<BugsInBacklogAsOfSprintEndResult, int>
    {
        private readonly IWorkItemContext _workItemContext;

        public BugsInBacklogAsOfSprintEndMetric(IWorkItemContext workItemContext)
        {
            _workItemContext = workItemContext;
        }

        public BugsInBacklogAsOfSprintEndResult Calculate(string project, string iterationPath)
        {
            if (project == null)
                throw new ArgumentNullException("project");
            if (iterationPath == null)
                throw new ArgumentNullException("iterationPath");

            Iteration iteration = _workItemContext.Iterations
                .Where(i => i.Project == project && i.Name == iterationPath)
                .ToList()
                .SingleOrDefault();

            if (iteration == null)
                throw new ArgumentException(string.Format(
                    CultureInfo.InvariantCulture,
                    "Unable to find an iteration based on project '{0}' and name '{1}'",
                    project,
                    iterationPath));

            List<Bug> bugs = _workItemContext.Bugs
                .Where(b =>
                    b.CreatedDate < iteration.FinishDate &&
                    b.State == "Active")
                .AsOf(iteration.FinishDate.Value.DateTime)
                .ToList();
            
            return new BugsInBacklogAsOfSprintEndResult(bugs.Count);
        }
    }
}