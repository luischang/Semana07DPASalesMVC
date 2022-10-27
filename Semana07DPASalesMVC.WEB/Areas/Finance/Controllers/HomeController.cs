using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Semana07DPASalesMVC.WEB.Areas.Finance.Models;

namespace Semana07DPASalesMVC.WEB.Areas.Finance.Controllers
{
    [Area("Finance")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductsWithViewData()
        {
            var products = GetProducts();
            ViewData["ProductList"] = products;
            ViewData["FullName"] = "Luis Chang";
            return View();
        }

        public IActionResult ProductsWithViewBag()
        {
            var products = GetProducts();
            ViewBag.ProductList = products;
            ViewBag.FullName = "Paolo Guerrero";
            return View();
        }

        public IActionResult ProductsWithViewModel()
        {
            var products = GetProducts();
            return View(products);
        }

        private IEnumerable<Product> GetProducts()
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Areas\\Finance\\Data\\products.json");
            var json = System.IO.File.ReadAllText(folder);

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            return products;
        }
    }
}
