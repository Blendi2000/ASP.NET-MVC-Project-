using Microsoft.AspNetCore.Mvc;

namespace GymWebApplication1.Areas.Costumer.Controllers
{
    public class HomeController : Controller
    {
        [Area("Costumer")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
