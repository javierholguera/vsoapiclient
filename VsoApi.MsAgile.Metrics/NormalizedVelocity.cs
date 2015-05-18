namespace VsoApi.MsAgile.Metrics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VsoApi.MsAgile.Entities;
    using VsoApi.MsAgile.Entities.Linq;

    public class NormalizedVelocity : IMetric<decimal>
    {
        private readonly IWorkItemContext _workItemContext;
        private readonly decimal _maxHours;

        public NormalizedVelocity(IWorkItemContext workItemContext)
            : this(workItemContext, 4 * 40 * 2) { }

        public NormalizedVelocity(IWorkItemContext workItemContext, decimal maxHours)
        {
            if (workItemContext == null)
                throw new ArgumentNullException("workItemContext");

            _workItemContext = workItemContext;
            _maxHours = maxHours;
        }

        public decimal Calculate(string project, string iterationPath)
        {
            if (project == null)
                throw new ArgumentNullException("project");
            if (iterationPath == null)
                throw new ArgumentNullException("iterationPath");

            Capacity result = _workItemContext.CapacityInfos
                .Where(u => u.IterationName == iterationPath)
                .ToList()
                .Single();

            decimal actualHours = result.Entries.Sum(e => e.AvailableHours);
            
            // The more availability, the smaller the correction factor will be.
            // Therefore less hours (bigger factor) will "pump up" the velocity once
            // applied to the real velocity
            decimal correctionFactor = _maxHours / actualHours;

            List<UserStory> userStories = _workItemContext.UserStories
                .Where(userStory => 
                    userStory.Project == project && 
                    userStory.IterationPath == iterationPath &&
                    userStory.State == "Closed")
                .ToList();

            return userStories.Sum(u => u.StoryPoints ?? 0) * correctionFactor;
        }
    }
}