using Microsoft.AspNetCore.Mvc;
using Semana07DPASalesMVC.WEB.Models;
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

        [HttpPost]
        public async Task<IActionResult> Grabar(int idCliente
            , string nombre, string apellido, string ciudad
            , string pais, string telefono)
        {
            bool exito = true;
            if (idCliente != -1)
            {
                //update customer
                var customer = new CustomerViewModel()
                {
                    Id = idCliente,
                    FirstName = nombre,
                    LastName = apellido,
                    City = ciudad,
                    Country = pais,
                    Phone = telefono
                };

                exito = await CustomerService.UpdateCustomer(customer);
            }
            else {
                //Insert new customer
                var customer = new CustomerInsertViewModel()
                {
                    FirstName = nombre,
                    LastName = apellido,
                    City = ciudad,
                    Country = pais,
                    Phone = telefono
                };
                exito = await CustomerService.InsertCustomer(customer);
            }
            return Json(exito);
        }

        public async Task<IActionResult> Eliminar(int id) {
            bool exito = await CustomerService.DeleteCustomer(id);
            return Json(exito);
        }

        public async Task<IActionResult> Obtener(int id) {
            var customer = await CustomerService.GetCustomerById(id);
            return Json(customer);
        }
    }
}
