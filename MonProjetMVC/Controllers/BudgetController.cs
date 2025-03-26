using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    public class BudgetController : Controller
    {
        private readonly ILogger<BudgetController> _logger;
        private readonly ApiService _apiService;
        public BudgetController(ILogger<BudgetController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public async Task<IActionResult> Budgets()
        {
            // string jsessionId = "1BFCA94C5AC72E401635931C772F9FBB";
            // var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/oauth/budgets");
            var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync2("/api/oauth/budgets");
            List<Budget>? budgets = JsonSerializer.Deserialize<List<Budget>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Console.WriteLine("Liste des Budgets:");
            foreach (var budget in budgets)
            {
                Console.WriteLine($"ID: {budget.id}, Valeur: {budget.valeur}, Client: {budget.customer.name}");
            }
            return View(budgets);

        }
        public async Task<IActionResult> Envoyer()
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            var budget = new Role
            {
                id = 1,
                name = "Mande"
            };

            var response = await _apiService.EnvoyerBudgetAsync(budget, jsessionId, "http://localhost:8080/api/oauth/Prendrebudgets");

            Console.WriteLine("Réponse de l'API: " + response);
            return View("Confirmation", response);
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