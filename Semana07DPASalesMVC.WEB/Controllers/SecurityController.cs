using Microsoft.AspNetCore.Mvc;
using Semana07DPASalesMVC.WEB.Models;
using Semana07DPASalesMVC.WEB.Services;

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
        public async Task<IActionResult> Validate(string correo, string clave)
        {
            var userAuth = new UsersAuthenticationViewModel()
            {
                Email = correo,
                Password = clave
            };

            var userResponse = await UsersService.Login(userAuth);
            if (userResponse == null)
                return RedirectToAction("Login", "Security");

            var roleCode = userResponse.RoleCode;
            if (roleCode == "MARKETING")
                return RedirectToAction("Index", "Home", new { Area = "Marketing" });
            else if (roleCode == "FINANCE")
                return RedirectToAction("Index", "Home", new { Area = "Finance" });
            else
                return RedirectToAction("Login", "Security");

            //if (correo == "finance@peru.com" && clave == "finance123")
            //{
            //    return RedirectToAction("Index", "Home", new { Area = "Finance" });
            //}
            //else if (correo == "marketing@peru.com" && clave == "marketing123")
            //{
            //    return RedirectToAction("Index", "Home", new { Area = "Marketing" });

            //}
            //else {
            //    return RedirectToAction("Login","Security");
            //}
        }


    }
}
