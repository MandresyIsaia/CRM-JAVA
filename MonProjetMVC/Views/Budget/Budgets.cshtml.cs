using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Budget
{
    public class Budgets : PageModel
    {
        private readonly ILogger<Budgets> _logger;

        public Budgets(ILogger<Budgets> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}