using Microsoft.AspNetCore.Mvc;
using RRBL;
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
        private IRestaurantBL _restBL;

        public RestaurantController(IRestaurantBL p_restBL)
        {
            _restBL = p_restBL;
        }

        // GET: api/<RestaurantController>
        [HttpGet("all")]
        //The method name doesn't need to be exactly the same as anything
        //You can make a more meaningful method name
        public IActionResult GetAllRestaurant()
        {
            return Ok(_restBL.GetAllRestaurant());
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
