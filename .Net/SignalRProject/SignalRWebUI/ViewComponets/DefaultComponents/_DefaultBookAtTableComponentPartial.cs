using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponets.DefaultComponents
{
    public class _DefaultBookAtTableComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
