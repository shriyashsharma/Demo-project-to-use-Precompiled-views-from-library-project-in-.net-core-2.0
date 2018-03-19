using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class HomeLibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutLibrary()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult ContactLibrary()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
