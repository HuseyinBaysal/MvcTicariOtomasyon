using MvcTicariOtomasyon.Infrastructure;
using MvcTicariOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        OtomasyonDbContext dbContext = new OtomasyonDbContext();
        // GET: Product
        public ActionResult Index()
        {
            //Ürünler listesinde durumu aktif(true) olanlar görüntülensin
            var products = dbContext.Products.Where(x => x.Condition == true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> dropList = (from x in dbContext.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.dropList = dropList;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var deletedProduct = dbContext.Products.Find(id);
            deletedProduct.Condition = false;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> dropList = (from x in dbContext.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value =x.CategoryID.ToString(),
                                             }).ToList();

            ViewBag.dropList = dropList;

            var selectedProduct = dbContext.Products.Find(id);
            return View("Getproduct",selectedProduct);
        }

        public ActionResult UpdateProduct(Product product)
        {
            var updateProduct = dbContext.Products.Find(product.ProductID);
            updateProduct.ProductName = product.ProductName;
            updateProduct.Marka = product.Marka;
            updateProduct.Stok = product.Stok;
            updateProduct.PurchasePrice = product.PurchasePrice;
            updateProduct.SalePrice = product.SalePrice;
            updateProduct.Category.CategoryName = product.Category.CategoryName;
            updateProduct.ProductImage = product.ProductImage;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var products = dbContext.Products.ToList();
            return View(products);
        }
    }
}