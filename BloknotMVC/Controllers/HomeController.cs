using BloknotMVC.Models;
using BloknotMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BloknotMVC.Controllers
{
    public class HomeController : Controller
    {
        ILoggerService _logger;

        public HomeController(ILoggerService logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.WriteLog("Home page requested");
            return View();
        }
    }
}