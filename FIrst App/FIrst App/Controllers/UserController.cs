using FIrst_App.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using FIrst_App.Services;
using FIrst_App.Attributes.SessionCheckAttribute;

namespace FIrst_App.Controllers
{
    public class UserController(DatabaseOperations dbOps) : Controller
    {
        [SessionCheck]
        public IActionResult Index()
        {
            var movieData = dbOps.getAllMovie();
            return View(movieData);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
