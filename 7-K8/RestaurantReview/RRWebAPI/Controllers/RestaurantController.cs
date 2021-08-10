using Microsoft.AspNetCore.Mvc;
using RRBL;
using RRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRWebAPI.Controllers
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
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurant()
        {
            return Ok(await _restBL.GetAllRestaurantAsync());
        }

        // GET api/<RestaurantController>/5
        [HttpGet("get/{p_id}")]
        public async Task<IActionResult> GetRestaurantById(int p_id)
        {
            return Ok(await _restBL.GetRestaurantAsync(p_id));
        }

        // POST api/<RestaurantController>
        [HttpPost("add")]
        public async Task<IActionResult> AddRestaurant([FromBody] Restaurant p_rest)
        {
            return Created("api/Restaurant/add", await _restBL.AddRestaurantAsync(p_rest));
        }

        //DELETE api/<RestaurantController>/5
        [HttpDelete("delete/{p_id}")]
        public async Task<IActionResult> DeleteRestaurant(int p_id)
        {
            return Ok(await _restBL.DeleteRestaurantAsync(await _restBL.GetRestaurantAsync(p_id)));
        }
    }
}
