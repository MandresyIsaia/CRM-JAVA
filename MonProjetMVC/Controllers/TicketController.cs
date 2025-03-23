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

    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ApiService _apiService;

        public TicketController(ILogger<TicketController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public async Task<IActionResult> GetTicket()
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/tickets");
            Console.WriteLine(jsonResponse);
            List<Depense>? budgets = JsonSerializer.Deserialize<List<Depense>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View("Tickets", budgets);

        }
        public async Task<IActionResult> Suprimmer(string nom)
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = "id",
                valeur = Convert.ToDouble(nom)
            };
            var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/deleteTicket");

            Console.WriteLine("Réponse de l'API: " + response);
            return RedirectToAction("GetTicket");
        }
        [HttpPost]
        public async Task<IActionResult> ModificationTicket(double nom, string id)
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = id,
                valeur = nom
            };
            var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/modificationTicket");

            Console.WriteLine("Réponse de l'API: " + response);
            return RedirectToAction("GetTicket");
        }
        public async Task<IActionResult> Modifier(string nom)
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = "id",
                valeur = Convert.ToDouble(nom)
            };
            var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/getModificationTicket");

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