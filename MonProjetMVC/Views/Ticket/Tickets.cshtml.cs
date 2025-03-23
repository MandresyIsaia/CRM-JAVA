using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Ticket
{
    public class Tickets : PageModel
    {
        private readonly ILogger<Tickets> _logger;

        public Tickets(ILogger<Tickets> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}