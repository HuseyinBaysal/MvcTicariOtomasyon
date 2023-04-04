using MvcTicariOtomasyon.Infrastructure;
using MvcTicariOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        OtomasyonDbContext dbContext = new OtomasyonDbContext();

        // GET: Category
        public ActionResult Index()
        {
            var categories = dbContext.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var deletedCategory = dbContext.Categories.Find(id);
            dbContext.Categories.Remove(deletedCategory);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var selectedCategory = dbContext.Categories.Find(id);
            return View("GetCategory",selectedCategory);
        }
        public ActionResult UpdateCategory(Category category)
        {
            var updateCategory = dbContext.Categories.Find(category.CategoryID);
            updateCategory.CategoryName = category.CategoryName;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}