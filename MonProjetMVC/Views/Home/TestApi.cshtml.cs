using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Home
{
    public class TestApi : PageModel
    {
        private readonly ILogger<TestApi> _logger;

        public TestApi(ILogger<TestApi> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}