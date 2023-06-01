using DeAn.Models;
using System;

using System.Collections.Generic;

using System.Data;
using System.Data.Entity;

using System.Linq;
using System.Net;

using System.Web;
using System.Web.Mvc;


namespace DeAn.Controllers
{
    public class ProductController : Controller
    {
        DBSportStoreEntities2 db = new DBSportStoreEntities2();
        // GET: Product
        public ActionResult Index()

        {
            var products = db.Products.Include(p => p.Category1);

            return View(products.ToList());

        }
        public ActionResult ProductList(string category, string SearchString, double min = double.MinValue, double max = double.MaxValue)
        {
            var products = db.Products.Include(p => p.Category);
            // Tìm kiếm chuỗi truy vấn theo category
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.NamePro.Contains(SearchString));
            }
            // Tìm kiếm chuỗi truy vấn theo đơn giá
            if (min >= 0 && max > 0)
            {
                products = db.Products.OrderByDescending(x => x.Price).Where(p =>
               (double)p.Price >= min && (double)p.Price <= max);
            }
            if (category == null)
            {
                products = db.Products.OrderByDescending(x => x.NamePro);
            }
            else
            {
                products = db.Products.OrderByDescending(x => x.Category).Where(x => x.Category ==
               category);
            }
            // Tìm kiếm chuỗi truy vấn theo NamePro (SearchString)
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.NamePro.Contains(SearchString));
            }
            // Tìm kiếm chuỗi truy vấn theo đơn giá
            if (min >= 0 && max > 0)
            {
                products = db.Products.OrderByDescending(x => x.Price).Where(p =>
               (double)p.Price >= min && (double)p.Price <= max);
            }
          
            return View(products.ToList());
        }
        public ActionResult Timkiem(string SearchString)
        {
            var products = db.Products.Include(p => p.Category);
            //Tìm kiếm chuỗi truy vấn theo NamePro, nếu chuỗi truy vấn SearchString khác rỗng, null
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.NamePro.Contains(SearchString));
            }
            return View(products.ToList());
        }
    }
}
