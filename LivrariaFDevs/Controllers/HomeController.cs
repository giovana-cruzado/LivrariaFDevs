using Microsoft.AspNetCore.Mvc;

namespace LivrariaFDevs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
