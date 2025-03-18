using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponets._LayoutCompontes._LayoutCompontes
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
