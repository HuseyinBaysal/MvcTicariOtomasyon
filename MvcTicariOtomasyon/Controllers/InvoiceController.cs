using MvcTicariOtomasyon.Infrastructure;
using MvcTicariOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        OtomasyonDbContext dbContext = new OtomasyonDbContext();
        // GET: Invoice
        public ActionResult Index()
        {
            var invoices = dbContext.Invoices.ToList();
            return View(invoices);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            dbContext.Invoices.Add(invoice);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetInvoice(int id)
        {
            var selectedInvoice = dbContext.Invoices.Find(id);
            return View("GetInvoice",selectedInvoice);
        }
        public ActionResult UpdateInvoice(Invoice invoice)
        {
            var updatedInvoice = dbContext.Invoices.Find(invoice.InvoiceID);
            updatedInvoice.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            updatedInvoice.InvoiceRowNumber = invoice.InvoiceRowNumber;
            updatedInvoice.TaxAdministration = invoice.TaxAdministration;
            updatedInvoice.InvoiceDate = invoice.InvoiceDate;
            updatedInvoice.TaxTime = invoice.TaxTime;
            updatedInvoice.Receiver = invoice.Receiver;
            updatedInvoice.Submitter = invoice.Submitter;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetail()
        {
            return View();
        }
    }
}