using u20444550HW06.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6No3.Controllers
{
    public class OrderController : Controller
    {
        public BikeStoresEntities db = new BikeStoresEntities();
        // GET: Order
        public ActionResult Index(int? i)
        {
            return View(db.orders.ToList().ToPagedList(i ?? 1, 10));
        }


        [HttpPost]
        public ActionResult Index(DateTime date, int? i)
        {
            if (date.Equals(null))
            {
                return View(db.orders.ToList());
            }
            else
            {
                return View(db.orders.Where(x => x.order_date == date).ToList().ToPagedList(i ?? 1, 10));
            }

        }
    }
}