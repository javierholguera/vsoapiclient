namespace VsoApi.Client.Resources.WIT
{
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses.WIT;

    public interface ICapacityResource
    {
        SprintCapacityResponse Get(SprintCapacityRequest request);
        SprintCapacityResponse Post(SetSprintCapacityRequest request);
    }
}