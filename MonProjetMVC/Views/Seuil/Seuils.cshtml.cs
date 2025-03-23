using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Seuil
{
    public class Seuils : PageModel
    {
        private readonly ILogger<Seuils> _logger;

        public Seuils(ILogger<Seuils> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}