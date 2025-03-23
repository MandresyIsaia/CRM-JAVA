using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using System.Text;
namespace MonProjetMVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            // Création d'un HttpClient avec un CookieContainer pour gérer les cookies
            var handler = new HttpClientHandler
            {
                CookieContainer = new CookieContainer()
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://localhost:8080")  // Adresse de ton API Spring Boot
            };
        }

        // Méthode pour tester l'API avec le cookie JSESSIONID
        public async Task<string> TestOAuthApiWithSessionIdAsync(string jsessionId, string url)
        {
            // Créer un cookie JSESSIONID manuellement
            var uri = new Uri("http://localhost:8080");  // L'URL de ton API
            var cookie = new Cookie("JSESSIONID", jsessionId) { Domain = uri.Host };

            // Ajouter le cookie au CookieContainer
            _httpClient.DefaultRequestHeaders.Add("Cookie", $"{cookie.Name}={cookie.Value}");

            // Appel à l'API sécurisée
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return "Erreur lors de l'appel à l'API.";
            }

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> TestOAuthApiWithSessionIdAsync2(string url)
        {
            // Créer un cookie JSESSIONID manuellement
            // var uri = new Uri("http://localhost:8080");  // L'URL de ton API
            // var cookie = new Cookie("JSESSIONID", jsessionId) { Domain = uri.Host };

            // // Ajouter le cookie au CookieContainer
            // _httpClient.DefaultRequestHeaders.Add("Cookie", $"{cookie.Name}={cookie.Value}");

            // Appel à l'API sécurisée
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return "Erreur lors de l'appel à l'API.";
            }

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> EnvoyerBudgetAsync(object budget, string jsessionId, string url)
        {
            var uri = new Uri(url);
            var handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            handler.CookieContainer.Add(new Cookie("JSESSIONID", jsessionId) { Domain = uri.Host });

            using (var client = new HttpClient(handler))
            {
                var json = JsonSerializer.Serialize(budget);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                Console.Write(json);
                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return $"Erreur : {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                }

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> EnvoyerBudgetAsync2(object budget, string url)
        {
            // var uri = new Uri(url);
            // var handler = new HttpClientHandler();
            // handler.CookieContainer = new CookieContainer();
            // handler.CookieContainer.Add(new Cookie("JSESSIONID", jsessionId) { Domain = uri.Host });

            using (var client = new HttpClient())
            {
                var json = JsonSerializer.Serialize(budget);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                Console.WriteLine(json);
                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return $"Erreur : {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                }

                return await response.Content.ReadAsStringAsync();
            }
        }



    }
}