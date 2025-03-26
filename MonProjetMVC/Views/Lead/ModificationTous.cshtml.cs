using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MonProjetMVC.Views.Lead
{
    public class ModificationTous : PageModel
    {
        private readonly ILogger<ModificationTous> _logger;

        public ModificationTous(ILogger<ModificationTous> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}