using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponets.MenuComponents
{
    public class _MenuNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    }
