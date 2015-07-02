namespace VsoApi.Client.Resources.WIT
{
    using VsoApi.Contracts.Requests.WIT;
    using VsoApi.Contracts.Responses.WIT;

    public interface IClassificationNodeResource
    {
        ClassificationNodeResponse Get(AreaRequest request);
        ClassificationNodeResponse Get(IterationRequest request);
    }
}