using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonProjetMVC.Filter;

namespace MonProjetMVC.Controllers
{
    [SessionValidationFilter]

    public class User : Controller
    {
        private readonly ILogger<User> _logger;

        public User(ILogger<User> logger)
        {
            _logger = logger;
        }
        public IActionResult Logout()
        {
            Console.Write("logout");
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public IActionResult SaveName(String nom)
        {
            HttpContext.Session.SetString("UserName", nom);
            return RedirectToAction("Display");
        }

        public IActionResult Display()
        {
            string? userName = HttpContext.Session.GetString("UserName");
            return View((object?)userName);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}