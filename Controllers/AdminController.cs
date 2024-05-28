using Microsoft.AspNetCore.Mvc;

namespace AdventureSeekers.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
