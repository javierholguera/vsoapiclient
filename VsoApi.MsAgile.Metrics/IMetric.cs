namespace VsoApi.MsAgile.Metrics
{
    public interface IMetric<out T>
    {
        T Calculate(string project, string iterationPath);
    }
}