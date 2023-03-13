using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final_assignment.Controllers
{
    public class HomeController : Controller
    {
        MVCcrudDB4Context _context = new MVCcrudDB4Context();
        public ActionResult Index()
        {
            
            
            var employee = _context.Employees.OrderBy(x => x.name).ToList();
                          
            
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
                TempData["Message"] = "employee id successfully added to list";

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "employee id already exist in the system");
            }
            return View();
        }
           
          
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var data = _context.Employees.Where(x => x.employeeId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            var data = _context.Employees.Where(x => x.employeeId == emp.employeeId).FirstOrDefault();
            if (data != null)
            {
                data.name = emp.name;
                data.department = emp.department;
                data.salary= emp.salary;
                data.designation = emp.designation;
                data.managerId= emp.managerId;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = _context.Employees.Where(x => x.employeeId == id).FirstOrDefault();
            return View(data);

        }

        [HttpPost]
        public ActionResult Delete(Employee emp)
        {
            var data = _context.Employees.Where(x => x.employeeId == emp.employeeId).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = _context.Employees.Where(x => x.employeeId == id).FirstOrDefault();
            return View(data);

        }

        public ActionResult Manager() 
        {
            var managers = _context.Employees.Where(x => x.managerId == null).OrderBy(x => x.name).ToList(); 
            return View(managers); 
        }



    }
}