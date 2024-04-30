﻿using ApiDemo.Models;
using ApiDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly ModelService modelService;

        public MoviesController(ModelService _modelService) 
        {
            modelService = _modelService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Model model = new Model();
            if (modelService.getAllMovies(ref model) == true)
            {
                return this.Ok(new { Model = model, Status = "OK" });
            }
            else
            {
                return NotFound(new { Message = "Movies = null", Status = "OK" });
            }
        }

        // GET api/MoviesController
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Movie movie = new Movie();
            if (modelService.GetMovie(id, ref movie) == true)
            {
                return this.Ok(new { Movie = movie, Status = "OK" });
            }
            else
            {
                return NotFound(new { Id = id, Message = "Movie not found", Status = "OK" });
            }
        }

        // POST api/<MoviesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MoviesController>/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoviesController>/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
