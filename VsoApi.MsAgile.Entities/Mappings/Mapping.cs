namespace VsoApi.MsAgile.Entities.Mappings
{
    public static class Mapping
    {
        public static void Configure()
        {
            BaseEntityMapping.Configure();
            BugMapping.Configure();
            UserStoryMapping.Configure();
            TaskMapping.Configure();
        }
    }
}