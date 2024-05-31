namespace AspnextTemplate.Domain.Observability;

public interface IMetricsProvider
{
    void IncTestMetric(long metricLabel);
}
