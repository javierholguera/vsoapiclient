namespace VsoApi.MsAgile.Metrics
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using VsoApi.MsAgile.Entities;
    using VsoApi.MsAgile.Entities.Linq;

    public class BugsPerSprint
    {
        private readonly IWorkItemContext _workItemContext;

        public BugsPerSprint(IWorkItemContext workItemContext)
        {
            _workItemContext = workItemContext;
        }
        
        public int Calculate(string project, string iterationPath)
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
                    b.CreatedDate > iteration.StartDate && 
                    b.State != "Removed")
                .ToList();

            // We don't want to count bugs that where resolved with a reason different to being fixed
            int active = bugs.Count(b => b.State == "Active");
            int @fixed = bugs.Count(b => b.State != "Active" && b.ResolvedReason == "Fixed");

            return active + @fixed;
        }
    }
}