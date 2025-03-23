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

    public class GraphController : Controller
    {
        private readonly ApiService _apiService;
        private readonly ILogger<LeadController> _logger;
        public GraphController(ILogger<LeadController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public IActionResult Charts()
        {
            return View();
        }

        public async Task<IActionResult> GetGraphDataLead()
        {
            string? jsessionId = HttpContext.Session.GetString("JSessionId");
            var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/leadsDashboard");
            List<ReponseJSON>? budgets = JsonSerializer.Deserialize<List<ReponseJSON>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var jsonResponse1 = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/ticketsDashboard");
            List<ReponseJSON>? budgets1 = JsonSerializer.Deserialize<List<ReponseJSON>>(jsonResponse1, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var jsonResponse3 = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/ticketsTypeDashboard");
            List<ReponseJSON>? budgets3 = JsonSerializer.Deserialize<List<ReponseJSON>>(jsonResponse3, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            double[] nombreLeads = new double[12];
            double[] nombreTickets = new double[12];
            double[] sortTickets = new double[3];
            string[] labelsort = new string[3];
            for (int i = 0; i < budgets.Count; i++)
            {
                nombreLeads[i] = budgets[i].valeur;
                nombreTickets[i] = budgets1[i].valeur;
            }
            Console.WriteLine(budgets3.Count);
            for (int i = 0; i < budgets3.Count; i++)
            {
                labelsort[i] = budgets3[i].nom;
                sortTickets[i] = budgets3[i].valeur;
            }
            var data = new
            {
                labels = new[] { "Jan", "Fév", "Mar", "Avr", "Mai", "Juin", "Juillet", "Aout", "Septembre", "Octobre", "Decembre" },
                values1 = nombreLeads, // Pour Bar Chart
                values2 = nombreTickets,  // Pour Line Chart
                labels2 = labelsort,
                values3 = sortTickets  // Pour Pie Chart
            };

            return Json(data);
        }
    }
}