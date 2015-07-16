namespace VsoApi.MsAgile.Metrics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VsoApi.MsAgile.Entities;
    using VsoApi.MsAgile.Entities.Linq;

    public class NormalizedVelocityResult : IMetricResult<decimal>
    {
        public NormalizedVelocityResult(
            decimal theoreticalCapacity, decimal actualCapacity, decimal storyPoints, int supportDays)
        {
            if (supportDays < 0)
                throw new ArgumentOutOfRangeException("supportDays", supportDays, "Should be greater or equal than zero");
            if (theoreticalCapacity < 0)
                throw new ArgumentOutOfRangeException("theoreticalCapacity", theoreticalCapacity, "Should be greater or equal than zero");
            if (actualCapacity < 0)
                throw new ArgumentOutOfRangeException("actualCapacity", theoreticalCapacity, "Should be greater or equal than zero");
            if (storyPoints < 0)
                throw new ArgumentOutOfRangeException("storyPoints", storyPoints, "Should be greater or equal than zero");

            SupportDays = supportDays;
            TheoreticalCapacity = theoreticalCapacity;
            ActualCapacity = actualCapacity;
            StoryPoints = storyPoints;
        }

        public int SupportDays { get; private set; }
        public decimal TheoreticalCapacity { get; private set; }
        public decimal ActualCapacity { get; private set; }
        public decimal StoryPoints { get; private set; }

        public decimal Value
        {
            get
            {
                decimal correctionFactor = ActualCapacity / (TheoreticalCapacity - 4 * SupportDays);
                return StoryPoints / correctionFactor;
            }
        }
    }

    public class NormalizedVelocityMetric : IMetric<NormalizedVelocityResult, decimal>
    {
        private readonly IWorkItemContext _workItemContext;
        private readonly decimal _maxHours;

        public NormalizedVelocityMetric(IWorkItemContext workItemContext)
            : this(workItemContext, 4 * 40 * 2) { }

        public NormalizedVelocityMetric(IWorkItemContext workItemContext, decimal maxHours)
        {
            if (workItemContext == null)
                throw new ArgumentNullException("workItemContext");

            _workItemContext = workItemContext;
            _maxHours = maxHours;
        }

        public NormalizedVelocityResult Calculate(string project, string iterationPath)
        {
            if (project == null)
                throw new ArgumentNullException("project");
            if (iterationPath == null)
                throw new ArgumentNullException("iterationPath");

            int index = iterationPath.LastIndexOf('\\');
            string sprintName = iterationPath.Substring(index + 1, iterationPath.Length - index - 1);

            Iteration iteration = _workItemContext.Iterations
                .Where(it => it.Name == sprintName)
                .ToList()
                .Single();

            Capacity capacityInfo = _workItemContext.CapacityInfos
                .Where(u => u.IterationId == Guid.Parse(iteration.Id))
                .ToList()
                .Single();

            decimal actualHours = capacityInfo.Entries.Sum(e => e.AvailableHours);
            int supportDays = capacityInfo.SupportDays;

            // The more availability, the smaller the correction factor will be.
            // Therefore less hours (bigger factor) will "pump up" the velocity once
            // applied to the real velocity
            decimal correctionFactor = actualHours / (_maxHours - 4 * supportDays);

            List<UserStory> userStories = _workItemContext.UserStories
                .Where(userStory =>
                    userStory.Project == project &&
                    userStory.IterationPath == iterationPath &&
                    userStory.State == "Closed")
                .ToList();

            decimal actualStoryPoints = userStories.Sum(u => u.StoryPoints ?? 0);
            return new NormalizedVelocityResult(_maxHours, actualHours, actualStoryPoints, supportDays);
        }
    }
}