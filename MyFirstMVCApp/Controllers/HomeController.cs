using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Models;



namespace MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        

        public IActionResult Index()
        {
            String _user = "Arwa";
            HttpContext.Session.SetString("User", _user);
            ViewBag.Name = HttpContext.Session.GetString("User");

            Random _randNum = new Random();
            int n = _randNum.Next(0, 100);

            HttpContext.Session.SetString("RandNum", Convert.ToString(n));
            ViewBag.Num = HttpContext.Session.GetString("RandNum");


            


            

            return View();
        }

        public IActionResult About()
        {
            
  
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        public IActionResult Projects()
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
