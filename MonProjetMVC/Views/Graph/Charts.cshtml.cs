using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Graph
{
    public class Charts : PageModel
    {
        private readonly ILogger<Charts> _logger;

        public Charts(ILogger<Charts> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}