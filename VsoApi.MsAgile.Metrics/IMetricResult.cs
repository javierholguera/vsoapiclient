namespace VsoApi.MsAgile.Metrics
{
    public interface IMetricResult<out T>
    {
        T Value { get; }
    }
}