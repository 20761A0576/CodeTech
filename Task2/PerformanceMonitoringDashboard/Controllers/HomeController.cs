using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PerformanceMonitoringDashboard.Models;
using PerformanceMonitoringDashboard.Services;

namespace PerformanceMonitoringDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMetricsService _metricsService;

        public HomeController(ILogger<HomeController> logger, IMetricsService metricsService)
        {
            _logger = logger;
            _metricsService = metricsService;
        }

        public IActionResult Index()
        {
            var metrics = _metricsService.GetMetrics();
            return View(metrics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
