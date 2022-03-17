using Microsoft.AspNetCore.Mvc;
using Movies.MVC.Models;

namespace Movies.MVC.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Movie?nr=4").Result;

            var movies = response.Content.ReadAsAsync<List<MovieModel>>().Result;

            return View(movies);
        }

        public IActionResult Search(string searchString)    
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"Movie/search?name={searchString}").Result;

            var movies = response.Content.ReadAsAsync<List<MovieModel>>().Result;

            return View(movies);
        }

        public IActionResult DetailPage(string name)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"Movie/{name}").Result;

            var movie = response.Content.ReadAsAsync<MovieModel>().Result;

            return View(movie);
        }
    }
}
