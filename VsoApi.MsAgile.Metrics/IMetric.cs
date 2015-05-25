namespace VsoApi.MsAgile.Metrics
{
    public interface IMetric<out TResult, out TValue> where TResult : IMetricResult<TValue>
    {
        TResult Calculate(string project, string iterationPath);
    }
}