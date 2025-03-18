using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponets.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
