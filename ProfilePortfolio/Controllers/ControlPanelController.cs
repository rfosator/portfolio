﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProfilePortfolio.Controllers
{
    public class ControlPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
