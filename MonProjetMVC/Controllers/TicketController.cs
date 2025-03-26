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
using X.PagedList.Extensions;

namespace MonProjetMVC.Controllers
{
    [SessionValidationFilter]

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
            // string? jsessionId = HttpContext.Session.GetString("JSessionId");
            // var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/tickets");
            var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync2("/api/dashboard/tickets");
            Console.WriteLine(jsonResponse);
            List<Depense>? budgets = JsonSerializer.Deserialize<List<Depense>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View("Tickets", budgets);

        }
        public async Task<IActionResult> GetTicketTous(int? page)
        {
            int pageSize = 5;
            int pageNumber = page ?? 1;
            // string? jsessionId = HttpContext.Session.GetString("JSessionId");
            // var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/tickets");
            var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync2("/api/dashboard/ticketsTous");
            // Console.WriteLine(jsonResponse);
            List<Depense>? budgets = JsonSerializer.Deserialize<List<Depense>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var depenses = budgets
            .OrderByDescending(d => d.ticket.createdAt) // Tri par date de création
            .ToPagedList(pageNumber, pageSize);
            return View("TicketsTous", depenses);

        }
        public async Task<IActionResult> Suprimmer(string nom)
        {
            // string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = "id",
                valeur = Convert.ToDouble(nom)
            };
            // var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/deleteTicket");
            var response = await _apiService.EnvoyerBudgetAsync2(reponseJSON, "http://localhost:8080/api/dashboard/deleteTicket");

            Console.WriteLine("Réponse de l'API: " + response);
            return RedirectToAction("GetTicket");
        }
        public async Task<IActionResult> SuprimmerTous(string nom)
        {
            // string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = "id",
                valeur = Convert.ToDouble(nom)
            };
            // var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/deleteTicket");
            var response = await _apiService.EnvoyerBudgetAsync2(reponseJSON, "http://localhost:8080/api/dashboard/deleteTicket");


            return RedirectToAction("GetTicket");
        }
        [HttpPost]
        public async Task<IActionResult> ModificationTicket(double nom, string id)
        {
            // string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = id,
                valeur = nom
            };
            // var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/modificationTicket");
            var response = await _apiService.EnvoyerBudgetAsync2(reponseJSON, "http://localhost:8080/api/dashboard/modificationTicket");

            Console.WriteLine("Réponse de l'API: " + response);
            return RedirectToAction("GetTicket");
        }
        public async Task<IActionResult> Modifier(string nom)
        {
            // string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = "id",
                valeur = Convert.ToDouble(nom)
            };
            // var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/getModificationTicket");
            var response = await _apiService.EnvoyerBudgetAsync2(reponseJSON, "http://localhost:8080/api/dashboard/getModificationTicket");

            Console.WriteLine("Réponse de l'API: " + response);
            return View("Modification", JsonSerializer.Deserialize<Depense>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }));
        }
        [HttpPost]
        public async Task<IActionResult> ModificationTicketTous(double nom, string id)
        {
            // string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = id,
                valeur = nom
            };
            // var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/modificationTicket");
            var response = await _apiService.EnvoyerBudgetAsync2(reponseJSON, "http://localhost:8080/api/dashboard/modificationTicket");

            Console.WriteLine("Réponse de l'API: " + response);
            return RedirectToAction("GetTicketTous");
        }
        public async Task<IActionResult> ModifierTous(string nom)
        {
            // string? jsessionId = HttpContext.Session.GetString("JSessionId");
            ReponseJSON reponseJSON = new ReponseJSON
            {
                nom = "id",
                valeur = Convert.ToDouble(nom)
            };
            // var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/getModificationTicket");
            var response = await _apiService.EnvoyerBudgetAsync2(reponseJSON, "http://localhost:8080/api/dashboard/getModificationTicket");

            Console.WriteLine("Réponse de l'API: " + response);
            return View("ModificationTous", JsonSerializer.Deserialize<Depense>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }));
        }
        [HttpPost]
        public async Task<IActionResult> RechercheMultiCritere(DateTime dateDebut, DateTime dateFin, double valeur)
        {
            List<ReponseJSON> reponseJSONs = new List<ReponseJSON>();
            Console.WriteLine(int.MinValue);
            if (dateFin == DateTime.MinValue)
            {
                dateFin = DateTime.MaxValue;
            }
            ReponseJSON reponseJSON1 = new ReponseJSON
            {
                nom = dateDebut.ToString(),
                valeur = 0.0
            };
            ReponseJSON reponseJSON2 = new ReponseJSON
            {
                nom = dateFin.ToString(),
                valeur = 0.0
            };
            reponseJSONs.Add(reponseJSON1);
            reponseJSONs.Add(reponseJSON2);
            // var response = await _apiService.EnvoyerBudgetAsync(reponseJSON, jsessionId, "http://localhost:8080/api/dashboard/deleteTicket");
            var response = await _apiService.EnvoyerBudgetAsync2(reponseJSONs, "http://localhost:8080/api/dashboard/multicritereDepenseTicket");
            List<Depense>? budgets = JsonSerializer.Deserialize<List<Depense>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View("MultiCritere", budgets);
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