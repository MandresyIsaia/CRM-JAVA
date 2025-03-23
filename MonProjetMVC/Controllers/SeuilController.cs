using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonProjetMVC.Models;
using MonProjetMVC.Services;

namespace MonProjetMVC.Controllers
{
    public class SeuilController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ApiService _apiService;

        public SeuilController(ILogger<TicketController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public async Task<IActionResult> GetSeuil()
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/seuils");
            Console.WriteLine(jsonResponse);
            List<Seuil>? budgets = JsonSerializer.Deserialize<List<Seuil>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View("Seuils", budgets);

        }
        [HttpPost]
        public async Task<IActionResult> ModificationSeuil(double nom, string id)
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = id,
                valeur = nom
            };
            var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/modificationSeuil");

            Console.WriteLine("Réponse de l'API: " + response);
            return RedirectToAction("GetSeuil");
        }
        public async Task<IActionResult> Modifier(string nom)
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = "id",
                valeur = Convert.ToDouble(nom)
            };
            var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/getModificationSeuil");

            Console.WriteLine("Réponse de l'API: " + response);
            return View("Modification", JsonSerializer.Deserialize<Seuil>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }));
        }
    }
}