﻿using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class StatistikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
