using Microsoft.AspNetCore.Mvc;
using RRBL;
using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant _restBL;
        public RestaurantController(IRestaurant p_restBL)
        {
            _restBL = p_restBL;
        }
        // GET: api/<RestaurantController>
        [HttpGet("all")]
        public IActionResult GetAllRestaurant()
        {
            return Ok(_restBL.GetAllRestaurant());
        }

        // GET api/<RestaurantController>/5
        [HttpGet("get/{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            return Ok(_restBL.GetRestaurantById(id));
        }

        // POST api/<RestaurantController>
        [HttpPost("add")]
        public IActionResult AddRestaurant([FromBody] Restaurant newRest)
        {
            return Created("api/Restaurant/add",_restBL.AddRestaurant(newRest));
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            return Ok(_restBL.DeleteRestaurant(_restBL.GetRestaurantById(id)));
        }
    }
}
