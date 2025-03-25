using PerformanceMonitoringDashboard.Models;

namespace PerformanceMonitoringDashboard.Services
{
    public class MetricsService : IMetricsService
    {
        public List<MetricsModel> GetMetrics()
        {
            // Placeholder data
            return new List<MetricsModel>
            {
                new MetricsModel { MetricName = "CPU Usage", Value = 65.4, Timestamp = DateTime.UtcNow },
                new MetricsModel { MetricName = "Memory Usage", Value = 72.1, Timestamp = DateTime.UtcNow }
            };
        }
    }
}
