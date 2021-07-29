using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RRWebUI.Models;

namespace RRWebUI.Controllers
{
    /*
     * Responsible for controlling client requests and instantiation of models that a view might need
     */
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //This routes to the index.cshtml that is located in Views/Home
        public IActionResult Index()
        {
            return View(); //Returns the view
        }

        //This routes to the privacy.cshtml that is located in Views/Privacy
        public IActionResult Privacy()
        {
            return View(); //Returns the Privacy
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
