using FIrst_App.Enums;
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
            var isLoggedUser = userService.getUser(userModel);
            var isLoggedAdmin = userService.getAdmin(userModel);
            if (isLoggedAdmin)
            {
                var session = httpContextAccessor.HttpContext.Session;
                session.SetInt32("userId", userModel.Id);
                HttpContext.Session.SetInt32("UserRole", (int)Roles.Admin);
                return RedirectToAction("AllData", "Home");
            }
            else if (isLoggedUser)
            {
                var session = httpContextAccessor.HttpContext.Session;
                HttpContext.Session.SetInt32("UserRole", (int)Roles.User);
                session.SetInt32("userId", userModel.Id);
                return RedirectToAction("Index","User");
            }
            ModelState.Clear();
            ModelState.AddModelError("", "Invalid login credentials");
            return View("Index");
        }
        public IActionResult UserDashboard()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
