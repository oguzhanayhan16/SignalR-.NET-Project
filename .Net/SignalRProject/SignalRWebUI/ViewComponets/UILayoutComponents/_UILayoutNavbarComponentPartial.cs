﻿using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponets.UILayoutComponents
{
    public class _UILayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
