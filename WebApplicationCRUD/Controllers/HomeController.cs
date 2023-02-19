using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using WebApplicationCRUD.EF;

namespace WebApplicationCRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddProduct(Product model)
        {

            var db = new DB_TASKEntities1();
            db.Products.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        public ActionResult List()
        {
            var db = new DB_TASKEntities1();
            var Products = db.Products.ToList();
            return View(Products);
        }


        public ActionResult Details(int id)
        {
            var db = new DB_TASKEntities1();
            var st = (from s in db.Products
                      where s.PId == id
                      select s).SingleOrDefault();
            return View(st);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new DB_TASKEntities1();
            var st = (from s in db.Products
                      where s.PId == id
                      select s).SingleOrDefault();
            return View(st);
        }


        [HttpPost]
        public ActionResult Edit(Product model)
        {
            var db = new DB_TASKEntities1();
            var exst = (from s in db.Products
                        where s.PId == model.PId
                        select s).SingleOrDefault();
       
            db.Entry(exst).CurrentValues.SetValues(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        public ActionResult Delete(Product model)
        {

            var db = new DB_TASKEntities1();
            var exst = (from s in db.Products
                        where s.PId == model.PId
                        select s).SingleOrDefault();
            exst.PId = model.PId;
            exst.PName = model.PName;
            exst.PDescription= model.PDescription;
            db.Products.Remove(exst);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}