namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using IQToolkit;
    using VsoApi.Client;

    public class WorkItemContext
    {
        public WorkItemContext(VsoClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            WorkItemProvider provider = new WorkItemProvider(client);
            UserStories = new Query<UserStory>(provider);
        }

        public Query<UserStory> UserStories { get; private set; }
    }
}