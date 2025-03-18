using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto dto = new UserEditDto();
            dto.Surname = values.Surname;
            dto.UserName = values.UserName;
            dto.Name = values.Name;
            dto.Mail = values.Email;
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto dto)
        {
            if(dto.Password == dto.ConfirmPassword)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                user.Name = dto.Name;
                user.Surname = dto.Surname;
                user.Email = dto.Mail;
                user.UserName = dto.UserName;
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, dto.Password);
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Category");
            }
            return View(dto);
        }

    }
}
