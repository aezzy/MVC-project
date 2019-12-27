using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Controllers
{
    public class EmployeesController : Controller
    {
        public static List<Employees> empRecord = new List<Employees>();

        public IActionResult Index()
        {

            //by default these items will be shown everytime when the page is loaded
            if (empRecord.Count == 0)
            {
                empRecord.Add(new Employees { Id = 1, Name = "Ankur", City = "Malmö" });
                empRecord.Add(new Employees { Id = 2, Name = "Rahul", City = "Lund" });
            }

            return View(empRecord);
        }

        //this is to load the create page for input
       // GET:Default/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST:Default/Create
        [HttpPost]
        public IActionResult Create(Employees e)
        {
            empRecord.Add(e);
            return RedirectToAction("Index");
        }

        // GET:Default/Details
        public IActionResult Details(int Id, Employees e)
        {
            e = empRecord.Find(x => x.Id == e.Id);


            return View(e);
        }

        // GET:Default/Edit
        public IActionResult Edit(int? Id, Employees e)
        {
            e = empRecord.Find(x => x.Id == e.Id);


            return View(e);
        }

        //POST:Default/Edit
        [HttpPost]
        public IActionResult Edit(Employees e)
        {
            if (ModelState.IsValid)
            {
                var temp = empRecord.Find(x => x.Id == e.Id);
                empRecord.Remove(temp);
                empRecord.Add(e);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");


        }

        //GET: Default/Delete
        public IActionResult Delete(int? Id, Employees e)
        {
            e = empRecord.Find(x => x.Id == e.Id);
            empRecord.Remove(e);


            return View(e);
        }


    }
}