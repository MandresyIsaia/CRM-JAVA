using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Home
{
    public class DashBoard : PageModel
    {
        private readonly ILogger<DashBoard> _logger;

        public DashBoard(ILogger<DashBoard> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}