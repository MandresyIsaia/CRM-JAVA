using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MonProjetMVC.Filter
{
    public class SessionValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            if (string.IsNullOrEmpty(session.GetString("JSessionId")))
            {
                // Redirige vers la page de connexion si la session est vide
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
            Console.WriteLine("connecter");
            base.OnActionExecuting(context);
        }
    }
}