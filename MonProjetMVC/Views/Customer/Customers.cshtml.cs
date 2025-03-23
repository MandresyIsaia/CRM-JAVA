using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Customer
{
    public class Customers : PageModel
    {
        private readonly ILogger<Customers> _logger;

        public Customers(ILogger<Customers> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}