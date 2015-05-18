namespace VsoApi.MsAgile.Entities.Mappings
{
    public static class Mapping
    {
        public static void Configure()
        {
            BaseWorkItemMapping.Configure();
            BugMapping.Configure();
            UserStoryMapping.Configure();
            TaskMapping.Configure();

            IterationMapping.Configure();
            CapacityMapping.Configure();
        }
    }
}