using FIrst_App.Models;
using FIrst_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIrst_App.Controllers
{
    public class LoginController(UserService userService, IHttpContextAccessor httpContextAccessor) : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(UserModel userModel)
        {
            var isLoggedIn = userService.getUser(userModel);
            if (isLoggedIn)
            {
                var session = httpContextAccessor.HttpContext.Session;
                session.SetInt32("userId", userModel.Id);
                return RedirectToAction("AllData", "Home");
            }
            ModelState.AddModelError("", "Invalid login credentials");
            return View("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
