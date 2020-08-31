using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schedulers.Models;
using Schedulers.Schedulers.Setup;

namespace Schedulers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISchedulerService _schedulerService;

        public HomeController(ILogger<HomeController> logger, ISchedulerService schedulerService)
        {
            _logger = logger;
            _schedulerService = schedulerService;
        }

        public IActionResult Index()
        {
            return View(_schedulerService.GetViewModel());
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
