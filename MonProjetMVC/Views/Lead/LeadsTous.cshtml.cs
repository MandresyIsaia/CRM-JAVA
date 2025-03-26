using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Lead
{
    public class LeadsTous : PageModel
    {
        private readonly ILogger<LeadsTous> _logger;

        public LeadsTous(ILogger<LeadsTous> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}