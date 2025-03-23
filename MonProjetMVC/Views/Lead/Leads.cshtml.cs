using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Lead
{
    public class Leads : PageModel
    {
        private readonly ILogger<Leads> _logger;

        public Leads(ILogger<Leads> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}