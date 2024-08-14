using Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Helpers.Controllers
{
    public class BrandsController : Controller
    {
        EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();

        // GET: Brands
        public ActionResult Index()
        {
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}