using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RRBL;
using RRModels;
using RRWebUI.Models;

namespace RRWebUI.Controllers
{
    public class RestaurantController : Controller
    {
        //Remove these
        // private readonly ILogger<HomeController> _logger; 

        private IRestaurant _restBL;
        public RestaurantController(IRestaurant p_restBL)
        {
            _restBL = p_restBL;
        }

        // public RestaurantController(IRestaurant p_restBL, ILogger<HomeController> logger) : this(p_restBL)
        // {
        //     _logger = logger;
        // }

        public IActionResult Index()
        {
            return View(
                _restBL
                .GetAllRestaurant()
                .Select(rest => new RestaurantVM(rest))
                .ToList()
            );
        }

        [HttpGet] //Good practice but not needed (for code readability)
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Whenever a post request is received, run this instead
        [ValidateAntiForgeryToken] //Protects the end user from CSRF attacks
        public IActionResult Create(RestaurantVM restVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _restBL.AddRestaurant(new Restaurant(
                            restVM.Name,
                            restVM.City,
                            restVM.State
                        )
                    );

                    return RedirectToAction(nameof(Index)); //Go back to index html
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int p_id)
        {
            return View(new RestaurantVM(_restBL.GetRestaurantById(p_id))); //passes the restuarantVM model to the View 
        }

        [HttpPost] //Whenever a post request is received, run this instead
        [ValidateAntiForgeryToken] //Protects the end user from CSRF attacks
        public IActionResult Edit(int id, RestaurantVM restVM) //id parameter is case sensitive
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _restBL.UpdateRestaurant(new Restaurant(
                            id, //This is where the id parameter is
                            restVM.Name,
                            restVM.City,
                            restVM.State
                        )
                    );

                    return RedirectToAction(nameof(Index)); //Go back to index html
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int p_id)
        {
            return View(new RestaurantVM(_restBL.GetRestaurantById(p_id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _restBL.DeleteRestaurant(_restBL.GetRestaurantById(id));
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
