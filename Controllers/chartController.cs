using u20444550HW06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6No3.Controllers
{
    public class ChartController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();
        // GET: Chart
        public ActionResult Index()
        {
            int[] data = new int[]
            {
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 1).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 2).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 3).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 4).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 5).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 6).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 7).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 8).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 9).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 10).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 11).ToList().Sum(x => x.quantity),
                db.order_items.Where(x => x.products.category_id == 6 && x.orders.order_date.Month == 12).ToList().Sum(x => x.quantity),

            };
            ViewBag.GraphData = data;
            return View();
        }
    }
}
