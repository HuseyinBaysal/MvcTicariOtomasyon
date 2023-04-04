using MvcTicariOtomasyon.Infrastructure;
using MvcTicariOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        OtomasyonDbContext dbContext = new OtomasyonDbContext();
        // GET: Current
        public ActionResult Index()
        {
            var currents = dbContext.Currents.Where(x=>x.Condition == true).ToList();
            return View(currents);
        }
        [HttpGet]
        public ActionResult AddCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrent(Current current)
        {
            current.Condition = true;
            dbContext.Currents.Add(current);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int id)
        {
            var deletedCurrent = dbContext.Currents.Find(id);
            deletedCurrent.Condition = false;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrent(int id)
        {
            var selectedCurrent = dbContext.Currents.Find(id);
            return View("GetCurrent",selectedCurrent);
        }
        public ActionResult UpdateCurrent(Current current)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCurrent");
            }
            else
            {
                var updateCurrent = dbContext.Currents.Find(current.CurrentID);
                updateCurrent.CurrentFirstName = current.CurrentFirstName;
                updateCurrent.CurrentLastName = current.CurrentLastName;
                updateCurrent.CurrentCity = current.CurrentCity;
                updateCurrent.CurrentMail = current.CurrentMail;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult CustomerSales(int id)
        {
            var values = dbContext.SalesReports.Where(x => x.Currentid == id).ToList();
            var cr = dbContext.Currents.Where(x => x.CurrentID == id).Select(x => x.CurrentFirstName + " " + x.CurrentLastName).FirstOrDefault();
            ViewBag.crers = cr;
            return View(values);
        }
    }
}