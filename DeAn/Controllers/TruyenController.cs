using System;
using DeAn.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace DeAn.Controllers
{
    public class TruyenController : Controller
    {
        private DBSportStoreEntities2 db = new DBSportStoreEntities2();
        // GET: CustomerProducts
        public ActionResult Index()
        {
            var products = db.Products;
            return View(products.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

    }
}