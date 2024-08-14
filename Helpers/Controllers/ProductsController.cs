using Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpers.Controllers
{
    public class ProductsController : Controller
    {
        EFDBFirstDatabaseEntities db= new EFDBFirstDatabaseEntities();
        // GET: Products
        public ActionResult Index()
        {
            List<Product>products=db.Products.ToList();
            return View(products);
        }
        public ActionResult Delete(long productId)
        {
            Product product = db.Products.Where(temp=>temp.ProductID == productId).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(long id,Product P)
        {   
            Product existingproduct= db.Products.Where(temp=>temp.ProductID==id).FirstOrDefault();
            db.Products.Remove(existingproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            ViewBag.categories=db.Categories.ToList();
            ViewBag.brands=db.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}