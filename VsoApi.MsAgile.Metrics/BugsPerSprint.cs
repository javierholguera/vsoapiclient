namespace VsoApi.MsAgile.Metrics
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using VsoApi.MsAgile.Entities;
    using VsoApi.MsAgile.Entities.Linq;

    public class BugsPerSprintResult : IMetricResult<int>
    {
        public BugsPerSprintResult(int active, int @fixed)
        {
            Active = active;
            Fixed = @fixed;
        }

        public int Active { get; set; }
        public int Fixed { get; set; }

        public int Value { get { return Active + Fixed; }}
    }

    public class BugsPerSprintMetric : IMetric<BugsPerSprintResult, int>
    {
        private readonly IWorkItemContext _workItemContext;

        public BugsPerSprintMetric(IWorkItemContext workItemContext)
        {
            _workItemContext = workItemContext;
        }

        public BugsPerSprintResult Calculate(string project, string iterationPath)
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
                    b.CreatedDate > iteration.StartDate && 
                    b.CreatedDate < iteration.FinishDate &&
                    b.State != "Removed")
                .ToList();

            // We don't want to count bugs that where resolved with a reason different to being fixed
            int active = bugs.Count(b => b.State == "Active");
            int @fixed = bugs.Count(b => b.State != "Active" && b.ResolvedReason == "Fixed");

            return new BugsPerSprintResult(active, @fixed);
        }
    }
}