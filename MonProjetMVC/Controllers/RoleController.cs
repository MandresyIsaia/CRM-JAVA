using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonProjetMVC.Models;
using Newtonsoft.Json;

namespace MonProjetMVC.Controllers
{
    [Route("Role")]
    public class RoleController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;
        public RoleController(ApplicationDbContext context)
        {
            _httpClient = new HttpClient();
            _context = context;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {

            var produits = _context.Roles.ToList();
            return View(produits);
        }

        public async Task<ActionResult> getAllRole()
        {
            // string token = "kjflsdhbgsdgijro;wmnbfdsdert945tuw";
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using (HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:8080/api/users/roles"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Role> roles = JsonConvert.DeserializeObject<List<Role>>(data) ?? new List<Role>(); ;

                    return View(roles);
                }
                else
                {
                    throw new System.Exception("Erreur lors de la récupération des produits.");
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}