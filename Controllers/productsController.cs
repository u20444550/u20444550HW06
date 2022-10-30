using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using u20444550HW06.Models;
using Newtonsoft;

namespace u20444550HW06.Controllers
{
    public class productsController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();

        // GET: products
        public ActionResult Index(int? i)
        {
            var products = db.products.Include(p => p.brands).Include(p => p.categories);
            return View(products.ToList().ToPagedList(i ?? 1, 10));
        }

        [HttpPost]
        public ActionResult Index(string search, int? i)
        {
            var products = db.products.Include(p => p.brands).Include(p => p.categories);
            return View(products.Where(x => x.product_name.Contains(search)).ToList().ToPagedList(i ?? 1, 10));
        }

        public ActionResult Add()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult Edit(int productId)
        {
            return PartialView("Edit", db.products.Where(x => x.product_id == productId).ToList());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            return PartialView("Delete", db.products.Where(x => x.product_id == productId).ToList());

        }

        [HttpPost]
        public ActionResult Details(int productId)
        {
            ViewBag.stocks = db.stocks;
            return PartialView("Details", db.products.Include(p => p.stocks).Where(x => x.product_id == productId).ToList());
            
        }


        [HttpPost]
        public ActionResult AddProduct(products request )
        {


            db.products.Add(request);
            db.SaveChanges();
            return Json(request);

        }

        [HttpPost]
        public ActionResult DeleteProduct(products _product)
        {
            using (BikeStoresEntities db = new BikeStoresEntities())
            {
                products products = (from c in db.products
                                     where c.product_id == _product.product_id
                                     select c).FirstOrDefault();
                if (products != null)
                {
                    db.products.Remove(products);
                    db.SaveChanges();
                    return Json(products);
                }
            }

            return new EmptyResult();
        }
    }

    


}
