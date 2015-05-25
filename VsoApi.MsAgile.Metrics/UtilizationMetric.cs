namespace VsoApi.MsAgile.Metrics
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using VsoApi.MsAgile.Entities;
    using VsoApi.MsAgile.Entities.Linq;

    public class UtilizationResult : IMetricResult<decimal>
    {
        public UtilizationResult(IEnumerable<DeveloperUtilization> utilizationPerDeveloper)
        {
            if (utilizationPerDeveloper == null)
                throw new ArgumentNullException("utilizationPerDeveloper");

            UtilizationByDeveloper = utilizationPerDeveloper;
        }

        public IEnumerable<DeveloperUtilization> UtilizationByDeveloper { get; private set; }

        public decimal Value
        {
            get { 
                return decimal.Round(
                    UtilizationByDeveloper.Sum(d => d.CompletedHours) / 
                    UtilizationByDeveloper.Sum(d => d.SprintCapacity) * 100, 2); 
            }
        }

        public class DeveloperUtilization
        {
            public DeveloperUtilization(string teamMember, decimal sprintCapacity, decimal completedHours)
            {
                TeamMember = teamMember;
                SprintCapacity = sprintCapacity;
                CompletedHours = completedHours;
            }

            public string TeamMember { get; private set; }
            public decimal SprintCapacity { get; private set; }
            public decimal CompletedHours { get; private set; }

            public decimal Utilization
            {
                get
                {
                    if (SprintCapacity == 0)
                        return 0;

                    return decimal.Round(CompletedHours/SprintCapacity*100, 2);
                }
            }
        }
    }

    public class UtilizationMetric : IMetric<UtilizationResult, decimal>
    {
        private readonly IWorkItemContext _workItemContext;

        public UtilizationMetric(IWorkItemContext workItemContext)
        {
            if (workItemContext == null)
                throw new ArgumentNullException("workItemContext");

            _workItemContext = workItemContext;
        }

        public UtilizationResult Calculate(string project, string iterationPath)
        {
            List<Task> tasks = _workItemContext.Tasks
                .Where(t => t.Project == project && t.IterationPath == iterationPath)
                .ToList();

            int index = iterationPath.LastIndexOf('\\');
            string sprintName = iterationPath.Substring(index + 1, iterationPath.Length - index - 1);

            Capacity capacityInfo = _workItemContext.CapacityInfos
                .Where(u => u.IterationName == sprintName)
                .ToList()
                .Single();

            var resultsByDev = new Collection<UtilizationResult.DeveloperUtilization>();

            List<IGrouping<string, Task>> groupByDeveloper = tasks
                .Where(t => string.IsNullOrWhiteSpace(t.AssignedTo) == false) // ignore unassigned tasks
                .GroupBy(t => t.AssignedTo).ToList();
            foreach (IGrouping<string, Task> developerTasks in groupByDeveloper) {

                CapacityEntry devCapacity = capacityInfo.Entries.Single(entry => entry.TeamMember == developerTasks.Key);
                var devUtilization = new UtilizationResult.DeveloperUtilization(
                    devCapacity.TeamMember,
                    devCapacity.AvailableHours,
                    developerTasks.Sum(t => t.CompletedWork ?? 0m));
                resultsByDev.Add(devUtilization);
            }

            return new UtilizationResult(resultsByDev);
        }
    }
}