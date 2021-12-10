using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RRBL;
using RRModels;
using RRWebUI.Models;

namespace RRWebUI.Controllers
{
    public class ReviewController : Controller
    {

        IReview _revBL;
        IRestaurant _restBL;

        public ReviewController(IReview revBL, IRestaurant restBL)
        {
            _revBL = revBL;
            _restBL = restBL;
        }

        public IActionResult Index(int p_id)
        {
            //ViewBag dynamicall infers the type and we will use it to refer it in cshtml
            ViewBag.Restaurant = _restBL.GetRestaurantById(p_id);
            Tuple<List<Review>, double> result = _revBL.GetReviews(_restBL.GetRestaurantById(p_id));

            if (result.Item1.Count > 0)
            {
                ViewData.Add("OverallRating", result.Item2); //We use ViewData to create a variable that we can use in the cshtml
            }
            else
            {
                ViewData.Add("OverallRating", "No Reviews Yet");
            }

            return View(result.Item1.Select(rev => new ReviewVM(rev)).ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
