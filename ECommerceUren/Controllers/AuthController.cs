using Microsoft.AspNetCore.Mvc;

namespace ECommerceUren.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        public IActionResult Login()
        {
            return View();
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}

        public IActionResult Logout()
        {
            return View();
        }
    }
}
