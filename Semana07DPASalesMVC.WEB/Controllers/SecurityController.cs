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

        [HttpPost]
        public IActionResult Validate(string correo, string clave)
        {
            if (correo == "admin@peru.com" && clave == "admin123")
            {
                return RedirectToAction("Index", "Home");
            }
            else {
                return RedirectToAction("Login","Security");
            }
        }


    }
}
