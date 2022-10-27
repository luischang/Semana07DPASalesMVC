﻿using Microsoft.AspNetCore.Mvc;

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
            if (correo == "finance@peru.com" && clave == "finance123")
            {
                return RedirectToAction("Index", "Home", new { Area = "Finance" });
            }
            else if (correo == "marketing@peru.com" && clave == "marketing123")
            {
                return RedirectToAction("Index", "Home", new { Area = "Marketing" });

            }
            else {
                return RedirectToAction("Login","Security");
            }
        }


    }
}
