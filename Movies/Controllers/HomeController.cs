using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Interfaces;
using Movies.Logic;
using Movies.Models;

namespace Movies.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieLogic _movieLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger">Logger injected</param>
        /// <param name="movieRepository">Movie repository injected</param>
        /// <param name="movieExternalService">Movie external service injected</param>
        public HomeController(
            ILogger<HomeController> logger, 
            IMovieRepository movieRepository, 
            IMovieExternalService movieExternalService)
        {
            _logger = logger;
            _movieLogic = new MovieLogic(movieRepository, movieExternalService);
        }

        /// <summary>
        /// Main action
        /// </summary>
        /// <returns>Main view</returns>
        public IActionResult Index()
        {
            var movies = _movieLogic.GetAllMovies();
            ViewData["Movies"] = movies;

            return View();
        }

        /// <summary>
        /// Movie details action
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie details view</returns>
        public IActionResult MovieDetails(string id)
        {
            var movie = _movieLogic.GetMovie(id);
            ViewData["Movie"] = movie;
            
            return View();
        }

        /// <summary>
        /// Rate movie action
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <param name="rate">Movie scoring</param>
        /// <returns>Rating view</returns>
        [HttpPost]
        public IActionResult RateMovie(string title, int rate)
        {
            // NOTE: Additional validation could be present, but too little time
            _movieLogic.RateMovie(title, rate);
            return View();
        }
    }
}