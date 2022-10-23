using Microsoft.AspNetCore.Mvc;

namespace Semana07DPASalesMVC.WEB.Areas.Marketing.Controllers
{
    [Area("Marketing")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
