using ECommerceUren.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerceUren.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(!await _roleManager.RoleExistsAsync("Admin"))
                {
                    IdentityRole role = new()
                    {
                        Name = "Admin"
                    };
                    await _roleManager.CreateAsync(role);
                }

                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    IdentityRole role = new()
                    {
                        Name = "User"
                    };
                    await _roleManager.CreateAsync(role);
                }

                IdentityUser user = new()
                {
                    UserName = model.FirstName+model.LastName,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if(model.Email == "admin@gmail.com" && model.Password == "Admin@123")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }

                    return RedirectToAction("Login");
                }
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(user!, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public IActionResult Forgetpassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forgetpassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid) { 
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {               
                    return RedirectToAction("Resetpassword", new {uId = user.Id});
                }
                return View();
            }
            return View(model);
        }

        public async Task<IActionResult> Resetpassword(string uId)
        {
            var user = await _userManager.FindByIdAsync(uId);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user!);
            if (user != null) {
                ResetPasswordViewModel model = new()
                {
                    Email = user.Email!,
                    ResetPasswordToken = token
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Resetpassword(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var rezult = await _userManager.ResetPasswordAsync(user!, model.ResetPasswordToken, model.Password);

            if (rezult.Succeeded)
            {
                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
