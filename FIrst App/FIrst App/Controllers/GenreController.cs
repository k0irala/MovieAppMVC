using FIrst_App.Attributes;
using FIrst_App.Models;
using FIrst_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace FIrst_App.Controllers
{
    [AdminOnly]
    public class GenreController(DatabaseOperations databaseOperations) : Controller

    {
        [HttpPost]
        public async Task<IActionResult> Add(GenreViewModel genreViewModel)
        {
            if (string.IsNullOrWhiteSpace(genreViewModel.GenreName))
            {
                ModelState.AddModelError("GenreName", "Genre name is required.");
                return View(genreViewModel); // Return the view with validation message
            }
            var genreName = genreViewModel.GenreName;
            Boolean isAdded = await databaseOperations.addGenre(genreViewModel,0,genreName);
            if (isAdded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("GenreName", "This genre already exists.");
            return View(new GenreViewModel());
        }
        public IActionResult Add()
        {
            return View(new GenreViewModel());
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var getGenre = await databaseOperations.getGenreById(id);
            return View("Add",getGenre);
        }
        [HttpPost]
        public IActionResult Edit(GenreViewModel genreModel)
        {
            var genreUpdateId = genreModel.Id;
            var updateGenreName = genreModel.GenreName;
            var isUpdated = databaseOperations.addGenre(genreModel, genreUpdateId,updateGenreName);
            if (isUpdated.Result)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("GenreName", "This genre already exists.");
            return RedirectToAction("Add");
        }
        public IActionResult Delete(int id)
        {
            var isDeleted = databaseOperations.deleteGenres(id);
            if (isDeleted.Result)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }
        public IActionResult AcccessDenied()
        {
            return RedirectToAction("AccessDenied","Home");
        }
        public IActionResult Index()
        {
            var allGenres = databaseOperations.getAllGenres();
            return View(allGenres);  
        }
    }
}
