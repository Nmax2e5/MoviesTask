using Microsoft.AspNetCore.Mvc;
using Movies.API.Entities;
using Movies.API.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Movies.API.Controllers
{
    public class MovieController : BaseApiController
    {
        private readonly IHelper _helper;

        public MovieController(IHelper helper)
        {
            _helper = helper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies([FromQuery] int nr)  
        {
            var movies = _helper.ReadFile<List<Movie>>("moviedata.json");

            if (movies == null) 
                return NotFound();

            return Ok(movies.OrderByDescending(x => x.Year).Take(nr).ToList());
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Movie>>> SearchMovie([FromQuery] string name)       
        {
            var movies = _helper.ReadFile<List<Movie>>("moviedata.json");

            if (movies == null)
                return NotFound();

            return Ok(movies.Where(x => x.Title.ToLower().Contains(name.ToLower())).OrderByDescending(x => x.Year).Take(10).ToList());
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<Movie>> GetMovieByName(string title)
        {
            var movies = _helper.ReadFile<List<Movie>>("moviedata.json");

            var movie = movies!.FirstOrDefault(x => x.Title.Equals(title));

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }
    }
}
