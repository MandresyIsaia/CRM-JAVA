using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Ticket
{
    public class MultiCritere : PageModel
    {
        private readonly ILogger<MultiCritere> _logger;

        public MultiCritere(ILogger<MultiCritere> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}