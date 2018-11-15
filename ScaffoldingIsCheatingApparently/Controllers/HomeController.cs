using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScaffoldingIsCheatingApparently.Models;

namespace ScaffoldingIsCheatingApparently.Controllers
{
    public class HomeController : Controller
    {
        private CoffeeShopDBLab23Entities DB = new CoffeeShopDBLab23Entities();
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
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return View("List");
            }
            Item item = DB.Items.Find(id);
            return View(item);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return View("List");
            }
            Item item = DB.Items.Find(id);
            return View(item);
        }
        public ActionResult AddItem(Item item)
        {
            CoffeeShopDBLab23Entities DB = new CoffeeShopDBLab23Entities();
            if (ModelState.IsValid)
            {
                DB.Items.Add(item);
                DB.SaveChanges();
                return RedirectToAction("List");

            }
            return View(item);
        }
        public ActionResult SaveChanges(Item item)
        {
            CoffeeShopDBLab23Entities DB = new CoffeeShopDBLab23Entities();
            DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("List");
            
        }
        public ActionResult DeleteItem(Item item)
        {
            CoffeeShopDBLab23Entities DB = new CoffeeShopDBLab23Entities();
            DB.Items.Remove(item);
            DB.SaveChanges();
            return RedirectToAction("List");
        }
    }
}