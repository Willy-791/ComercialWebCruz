using ComercialWebMVCUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ComercialWebMVCUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                context.Result = RedirectToAction("Login", "login");
            }
        }
    }
}
