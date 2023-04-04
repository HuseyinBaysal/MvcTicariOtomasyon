using MvcTicariOtomasyon.Infrastructure;
using MvcTicariOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        OtomasyonDbContext dbContext = new OtomasyonDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = dbContext.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> dropList = (from x in dbContext.Departments.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmentName,
                                                 Value = x.DepartmentID.ToString()
                                             }).ToList();
            ViewBag.dropList = dropList;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> dropList = (from x in dbContext.Departments.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmentName,
                                                 Value = x.DepartmentID.ToString()
                                             }).ToList();
            ViewBag.dropList = dropList;

            var selectedEmployee = dbContext.Employees.Find(id);
            return View("GetEmployee",selectedEmployee);
        }

        public ActionResult UpdateEmployee(Employee employee)
        {
            var updateEmployee = dbContext.Employees.Find(employee.EmployeeID);
            updateEmployee.EmployeeFirstName = employee.EmployeeFirstName;
            updateEmployee.EmployeeLastName = employee.EmployeeLastName;
            updateEmployee.EmployeeImage = employee.EmployeeImage;
            updateEmployee.Departmentid = employee.Departmentid;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}