using ApiDemo.Models;
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
                return Ok(new { Model = model, Status = "OK" });
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
                return Ok(new { Movie = movie, Status = "OK" });
            }
            else
            {
                return NotFound(new { Id = id, Message = "Movie not found", Status = "OK" });
            }
        }

        // POST api/<MoviesController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (modelService.AddMovie(ref movie) == true)
            {
                return Ok(new { Message = "Movie Added.", Movie = movie, Status = "OK" });
            }
            else
            {
                return Conflict(new { Message = "Movie already exists or there is a movie with that ID.", ID = movie.Id, ExistingMovie = movie, Status = "OK" });
            }
        }

        // PUT api/<MoviesController>/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie movie)
        {
        }

        // DELETE api/<MoviesController>/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
