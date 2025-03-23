using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Seuil
{
    public class Modification : PageModel
    {
        private readonly ILogger<Modification> _logger;

        public Modification(ILogger<Modification> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}