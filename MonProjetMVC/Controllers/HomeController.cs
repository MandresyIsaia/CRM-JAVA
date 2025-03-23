using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MonProjetMVC.Models;
using MonProjetMVC.Services;
namespace MonProjetMVC.Controllers;

public class HomeController : Controller
{
    private readonly ApiService _apiService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ApiService apiService)
    {
        _logger = logger;
        _apiService = apiService;
    }


    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Precision(string nom)
    {
        if (nom.Equals("clients", StringComparison.OrdinalIgnoreCase))
        {
            return RedirectToAction("GetCustomers", "Customer");
        }
        else if (nom.Equals("leads", StringComparison.OrdinalIgnoreCase))
        {
            return RedirectToAction("GetLead", "Lead");
        }
        else
        {
            return RedirectToAction("GetTicket", "Ticket");
        }
    }

    [HttpPost]
    public IActionResult SaveName(String nom)
    {
        HttpContext.Session.SetString("JSessionId", nom);
        return RedirectToAction("Display");
    }

    public async Task<IActionResult> Display()
    {
        string? jsessionId = HttpContext.Session.GetString("JSessionId");
        var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/dashboard/total");
        // var jsonResponse = await _apiService.TestOAuthApiWithSessionIdAsync2("/api/dashboard/total");
        Console.WriteLine(jsonResponse);
        List<ReponseJSON>? budgets = JsonSerializer.Deserialize<List<ReponseJSON>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return View("DashBoard", budgets);
    }
    public IActionResult Logout()
    {
        Console.Write("logout");
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> TestApi()
    {
        string jsessionId = "BAD866D04E9FD7902C6D7504872FFC06"; // Remplace par le JSESSIONID récupéré manuellement
        var result = await _apiService.TestOAuthApiWithSessionIdAsync(jsessionId, "/api/oauth/budgets");
        // Retourner le résultat à la vue
        ViewData["ApiResponse"] = result;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
