using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;

        public RegisterController(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto dto)
        {
            var appUser = new AppUser()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Mail,
                UserName = dto.Username
            };
            var resutl = await _usermanager.CreateAsync(appUser, dto.Password);
            if (resutl.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
