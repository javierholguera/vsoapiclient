namespace VsoApi.MsAgile.Entities.Mappings
{
    using VsoApi.Contracts.Models;

    public static class Mapping
    {
        public static void Configure()
        {
            BaseWorkItemMapping.Configure();
            BugMapping.Configure();
            UserStoryMapping.Configure();
            TaskMapping.Configure();

            IterationMapping.Configure();
        }
    }
}