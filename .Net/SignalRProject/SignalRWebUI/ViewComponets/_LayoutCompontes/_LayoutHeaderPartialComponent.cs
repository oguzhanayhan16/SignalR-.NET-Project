using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponets._LayoutCompontes._LayoutCompontes
{
    public class _LayoutHeaderPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
