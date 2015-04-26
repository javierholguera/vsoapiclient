namespace VsoApi.MsAgile.Entities.Linq
{
    public interface IWorkItemContext
    {
        BaseEntityQuery<UserStory> UserStories { get; }
        BaseEntityQuery<Bug> Bugs { get; }
        BaseEntityQuery<Task> Tasks { get; }
    }
}