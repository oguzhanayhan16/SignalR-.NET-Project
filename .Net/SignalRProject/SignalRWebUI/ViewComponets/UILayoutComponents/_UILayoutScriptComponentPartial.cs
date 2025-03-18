using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponets.UILayoutComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
