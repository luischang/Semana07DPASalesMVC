using Microsoft.AspNetCore.Mvc;

namespace Semana07DPASalesMVC.WEB.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("Login");
        }


    }
}
