using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonProjetMVC.Services;

namespace MonProjetMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var response = await _loginService.IsValid(username, password);
            if (response.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("Display", "Home");
            }
            return View("Index");
        }
    }
}