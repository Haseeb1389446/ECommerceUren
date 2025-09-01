using Microsoft.AspNetCore.Mvc;

namespace ECommerceUren.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
