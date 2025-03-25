using PerformanceMonitoringDashboard.Models;

namespace PerformanceMonitoringDashboard.Services
{
    public interface IMetricsService
    {
        List<MetricsModel> GetMetrics();
    }
}
