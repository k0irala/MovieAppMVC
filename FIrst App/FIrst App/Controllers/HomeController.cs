using System.Diagnostics;
using FIrst_App.Models;
using FIrst_App.Services;
using FIrst_App.Attributes;
using Microsoft.AspNetCore.Mvc;


namespace FIrst_App.Controllers
{
    [AdminOnly]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly DatabaseOperations operations;
        public HomeController(ILogger<HomeController> logger, DatabaseOperations operations)
        {
            this.logger = logger;
            this.operations = operations;

        }

        [HttpPost]
        public IActionResult Save(MovieViewModel movieModel)
        {
            var rowsAffected = operations.AddMovie(movieModel, 0);

            if (rowsAffected.Result)
            {
                return RedirectToAction("AllData");
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)

        {
            var movieModel = await operations.getMovieById(id);
            var genres = operations.GetGenreSelectList();
            ViewBag.Genres = genres;
            if (movieModel == null)
            {
                return NotFound();
            }
            return View(movieModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieViewModel movieViewModel)
        {
            var movieModel = movieViewModel;
            var updateMovie = await operations.AddMovie(movieViewModel, movieModel.Id);
            return RedirectToAction("AllData");
        }
        public IActionResult AllData()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var movieData = operations.getAllMovie();
            if (movieData == null)
            {
                return View(new MovieViewModel());
            }
            return View(movieData);
        }

        public IActionResult Delete(int id)
        {
            var deleteMovie = operations.deleteMovie(id);
            if (deleteMovie.Result)
            {

                return RedirectToAction("AllData");
            }
            return NotFound();
        }
        public IActionResult Index()

        {
           var genres =  operations.GetGenreSelectList();
            ViewBag.Genres = genres;
            return View();
        }
    }
}
