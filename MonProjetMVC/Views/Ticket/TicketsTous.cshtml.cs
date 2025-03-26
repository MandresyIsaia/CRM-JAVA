using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Ticket
{
    public class TicketsTous : PageModel
    {
        private readonly ILogger<TicketsTous> _logger;

        public TicketsTous(ILogger<TicketsTous> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}