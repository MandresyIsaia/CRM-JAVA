using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonProjetMVC.Models;
using MonProjetMVC.Services;

namespace MonProjetMVC.Controllers
{

    public class LeadController : Controller
    {
        private readonly ILogger<LeadController> _logger;
        private readonly ApiService _apiService;

        public LeadController(ILogger<LeadController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public async Task<IActionResult> GetLead()
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/leads");
            List<Depense>? budgets = JsonSerializer.Deserialize<List<Depense>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View("Leads", budgets);

        }
        public async Task<IActionResult> Suprimmer(string nom)
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = "id",
                valeur = Convert.ToDouble(nom)
            };
            var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/deleteLead");

            Console.WriteLine("Réponse de l'API: " + response);
            return RedirectToAction("GetLead");
        }
        [HttpPost]
        public async Task<IActionResult> ModificationLead(double nom, string id)
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = id,
                valeur = nom
            };
            var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/modificationLead");

            Console.WriteLine("Réponse de l'API: " + response);
            return RedirectToAction("GetLead");
        }
        public async Task<IActionResult> Modifier(string nom)
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = "id",
                valeur = Convert.ToDouble(nom)
            };
            var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/getModificationLead");

            Console.WriteLine("Réponse de l'API: " + response);
            return View("Modification", JsonSerializer.Deserialize<Depense>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }));
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