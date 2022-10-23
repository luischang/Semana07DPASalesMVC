using Microsoft.AspNetCore.Mvc;

namespace Semana07DPASalesMVC.WEB.Areas.Finance.Controllers
{
    [Area("Finance")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
