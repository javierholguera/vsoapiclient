namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using VsoApi.Client;

    public class WorkItemContext
    {
        public WorkItemContext(VsoClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            WorkItemProvider provider = new WorkItemProvider(client);
            UserStories = new BaseEntityQuery<UserStory>(provider);
            Tasks = new BaseEntityQuery<Task>(provider);
        }

        public BaseEntityQuery<UserStory> UserStories { get; private set; }
        public BaseEntityQuery<Task> Tasks { get; private set; }
    }
}