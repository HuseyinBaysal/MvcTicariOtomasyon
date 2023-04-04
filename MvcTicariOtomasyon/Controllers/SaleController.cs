using MvcTicariOtomasyon.Infrastructure;
using MvcTicariOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        OtomasyonDbContext dbContext = new OtomasyonDbContext();
        // GET: Sale
        public ActionResult Index()
        {
            var sales = dbContext.SalesReports.ToList();
            return View(sales);
        }
        [HttpGet]
        public ActionResult AddSale()
        {
            List<SelectListItem> dropList1 = (from x in dbContext.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString(),
                                           }).ToList();
            ViewBag.dropList1 = dropList1;

            List<SelectListItem> dropList2 = (from x in dbContext.Currents.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CurrentFirstName + " " + x.CurrentLastName,
                                                  Value = x.CurrentID.ToString(),
                                              }).ToList();
            ViewBag.dropList2 = dropList2;

            List<SelectListItem> dropList3 = (from x in dbContext.Employees.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.EmployeeFirstName + " " + x.EmployeeLastName,
                                                  Value = x.EmployeeID.ToString(),
                                              }).ToList();
            ViewBag.dropList3 = dropList3;

            return View();
        }
        [HttpPost]
        public ActionResult AddSale(SalesReport sales)
        {
            sales.SalesDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            dbContext.SalesReports.Add(sales);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetSale(int id)
        {
            List<SelectListItem> dropList1 = (from x in dbContext.Products.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.ProductName,
                                                  Value = x.ProductID.ToString(),
                                              }).ToList();
            ViewBag.dropList1 = dropList1;

            List<SelectListItem> dropList2 = (from x in dbContext.Currents.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CurrentFirstName + " " + x.CurrentLastName,
                                                  Value = x.CurrentID.ToString(),
                                              }).ToList();
            ViewBag.dropList2 = dropList2;

            List<SelectListItem> dropList3 = (from x in dbContext.Employees.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.EmployeeFirstName + " " + x.EmployeeLastName,
                                                  Value = x.EmployeeID.ToString(),
                                              }).ToList();
            ViewBag.dropList3 = dropList3;

            var selectedSale = dbContext.SalesReports.Find(id);
            return View("GetSale",selectedSale);
        }

        public ActionResult UpdateSale(SalesReport sales)
        {
            var updateSales = dbContext.SalesReports.Find(sales.SalesReportID);
            updateSales.Currentid = sales.Currentid;
            updateSales.Piece = sales.Piece;
            updateSales.Price = sales.Price;
            updateSales.Employeeid = sales.Employeeid;
            updateSales.SalesDate = sales.SalesDate;
            updateSales.Total = sales.Total;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaleDetails(int id)
        {
            var selectedSale = dbContext.SalesReports.Where(x=>x.SalesReportID==id).ToList();
            return View(selectedSale);
        }
    }
}