﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SystemInfo.Models;

namespace SystemInfo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Information()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
