using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeBL;
using PokeModel;

/*
    Auto generate by utilizing aspnet-codegenerator tool
    https://docs.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-6.0

    -To start
    --Install tool first = dotnet tool install -g dotnet-aspnet-codegenerator
    --Add package to api project = dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

    -To Create a controller
    dotnet aspnet-codegenerator controller -name Pokemon -api -outDir Controllers -actions

    "dotnet aspnet-codegenerator controller" - creates a controller

    "-name {NameOfController}" - names the controller to whatever you put

    "-api" - Makes the controller restful style api

    "-outDir Controllers" - Puts the controller inside the Controllers folder in api project

    "-action" - Adds in action(methods) in your controller
*/

namespace PokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IPokemonBL _pokeBL;
        public PokemonController(IPokemonBL p_pokeBL)
        {
            _pokeBL = p_pokeBL;
        }

        /*
            [HttpGet] data annotation basically tells the compiler that the method will be an action inside of a controller
            specifically this will handle a GET request from the client and send a http response
        */
        [HttpGet("GetAll")]
        public IActionResult GetAllPokemon()
        {
            try
            {
                return Ok(_pokeBL.GetAllPokemon());
            }
            catch (SqlException)
            {
                //The API is responsible for sending the right resource and the right status code
                //In this case, if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }

        /*
            Parameterized action will help you get information from the client and to do some process based on that action
            You have to use "{nameOfParameter}" to specify what you need
            Don't forget to put it as a parameter on the action with the appropriate datatype
        */
        [HttpGet]
        public IActionResult GetPokemonByName([FromQuery] string pokeName)
        {
            try
            {
                return Ok(_pokeBL.SearchPokemon(pokeName));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        /*
            [FromBody] data annotation specifies that this action will look inside of the HTTP request body (which is in a json format) to grab the information it needs
            Usually helpful for large amount of data (creating an account)

            [HttpPost] This action will handle any post request from the client 
        */
        [HttpPost("Add")]
        public IActionResult Post([FromBody] Pokemon p_poke)
        {
            try
            {
                return Created("Successfully added",_pokeBL.AddPokemon(p_poke));
            }
            catch (System.Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT: api/Pokemon/5
        // [HttpPut("Update/{id}")]
        // public IActionResult Put(int id, [FromBody] Pokemon p_poke)
        // {
        //     p_poke.Id = id;

        //     try
        //     {
        //         return Ok(_pokeBL.UpdatePokemon(p_poke));
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return Conflict(ex.Message);
        //     }
        // }

        // DELETE: api/Pokemon/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
