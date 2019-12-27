using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Models;
namespace MyFirstMVCApp.Controllers
{
    public class FeverController : Controller
    {
        public IActionResult Index()
        {
           
                return View();
        }

        [HttpPost]
        public ActionResult Index(Temperature t)
        {
            String _user = "Arwa";
            HttpContext.Session.SetString("User", _user);
            ViewBag.Name = HttpContext.Session.GetString("User");

            if (t.TNumber > 37)
            {
                ViewBag.Message = "you have fever";
                return View(t);
            }
            else
            {
                ViewBag.Message = "You have no fever";
                return View(t);
            }

        }
    }

   


}
