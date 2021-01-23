using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymWebApplication1.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
