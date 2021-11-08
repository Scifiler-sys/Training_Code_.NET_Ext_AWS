using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRBL;
using RRWebUI.Models;
using RRModels;

namespace RRWebUI.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantBL _restBL;
        public RestaurantController(IRestaurantBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public IActionResult Index()
        {
            return View(
                _restBL.GetAllRestaurant()
                .Select(rest => new RestaurantVM(rest))
                .ToList()
            );
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantVM restVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _restBL.AddRestaurant(new Restaurant
                        {
                            Name = restVM.Name,
                            City = restVM.City,
                            State = restVM.State,
                            Revenue = restVM.Revenue
                        }
                    );

                    return RedirectToAction(nameof(Index)); //Go back to the index html of the Restaurant Controller
                }
            }
            catch (Exception)
            {
                return View();
            }

            return View();
        }
    }
}
