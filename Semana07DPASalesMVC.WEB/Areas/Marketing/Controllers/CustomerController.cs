using Microsoft.AspNetCore.Mvc;
using Semana07DPASalesMVC.WEB.Services;

namespace Semana07DPASalesMVC.WEB.Areas.Marketing.Controllers
{
    [Area("Marketing")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var customers = await CustomerService.GetCustomers();
            ViewBag.ListadoClientes = customers;
            return PartialView();
        }
    }
}
