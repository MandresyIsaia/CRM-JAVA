using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonProjetMVC.Services
{
    public class LoginService
    {
        public async Task<string> IsValid(string Username, string Password)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", Username),
                    new KeyValuePair<string, string>("password", Password)
                });

                var response = await client.PostAsync("http://localhost:8080/api/login", content);

                var content1 = await response.Content.ReadAsStringAsync();
                return content1;
            }
        }
    }

}