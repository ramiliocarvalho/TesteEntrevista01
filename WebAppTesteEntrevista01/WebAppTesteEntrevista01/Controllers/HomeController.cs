﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppTesteEntrevista01.Filters;
using WebAppTesteEntrevista01.Models;

namespace WebAppTesteEntrevista01.Controllers
{
    [PageUserLoged]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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