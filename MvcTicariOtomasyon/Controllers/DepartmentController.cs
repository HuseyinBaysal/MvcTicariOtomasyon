using MvcTicariOtomasyon.Infrastructure;
using MvcTicariOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        OtomasyonDbContext dbContext = new OtomasyonDbContext();

        // GET: Department
        public ActionResult Index()
        {
            var departments = dbContext.Departments.Where(x=>x.Condition == true).ToList();
            return View(departments);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            department.Condition = true;
            dbContext.Departments.Add(department);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var deletedDepartment = dbContext.Departments.Find(id);
            deletedDepartment.Condition = false;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartment(int id)
        {
            var selectedDepartment = dbContext.Departments.Find(id);
            return View("GetDepartment",selectedDepartment);
        }
        public ActionResult UpdateDepartment(Department department)
        {
            var updateDepartment = dbContext.Departments.Find(department.DepartmentID);
            updateDepartment.DepartmentName = department.DepartmentName;
            updateDepartment.Condition = department.Condition;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetails(int id)
        {
            var degerler = dbContext.Employees.Where(x => x.Departmentid == id).ToList();
            var departmentName = dbContext.Departments.Where(x => x.DepartmentID == id).Select(x => x.DepartmentName).FirstOrDefault();
            ViewBag.departmentName = departmentName;
            return View(degerler);
        }

        public ActionResult DepartmentEmployeeSales(int id)
        {
            var values = dbContext.SalesReports.Where(x => x.Employeeid == id).ToList();

            var per = dbContext.Employees.Where(x => x.EmployeeID == id).Select(x => x.EmployeeFirstName + " " + x.EmployeeLastName).FirstOrDefault();
            ViewBag.dpers = per;

            return View(values);
        }
    }
}