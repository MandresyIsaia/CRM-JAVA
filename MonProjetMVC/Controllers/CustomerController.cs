using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonProjetMVC.Filter;
using MonProjetMVC.Models;
using MonProjetMVC.Services;

namespace MonProjetMVC.Controllers
{
    [SessionValidationFilter]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ApiService _apiService;

        public CustomerController(ILogger<CustomerController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            // string? jsessionId = HttpContext.Session.GetString("JSessionId");
            // var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/customers");

            var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync2("/api/dashboard/customers");
            List<Budget>? budgets = JsonSerializer.Deserialize<List<Budget>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View("Customers", budgets);

        }
        [HttpGet]
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