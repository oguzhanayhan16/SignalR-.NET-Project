using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto dto)
        {
            var result = await signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Category");
            }

            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
