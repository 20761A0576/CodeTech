using Microsoft.AspNetCore.Mvc;
using PerformanceMonitoringDashboard.Services;

namespace PerformanceMonitoringDashboard.Controllers
{
    public class MetricsController : Controller
    {
        private readonly IMetricsService _metricsService;

        public MetricsController(IMetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        [HttpGet("api/metrics")]
        public IActionResult GetMetrics()
        {
            try
            {
                var metrics = _metricsService.GetMetrics();
                return Json(metrics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching metrics: {ex.Message}");
            }
        }
    }
}
