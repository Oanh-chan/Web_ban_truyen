using System;
using DeAn.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Collections;
using System.Data.Entity;

namespace B3TH.Controllers
{
    public class HomeController : Controller
    {
        private DBSportStoreEntities2 db = new DBSportStoreEntities2();
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult CategoryPartial()
        {
            var cateList = db.Categories.ToList();
            return PartialView(cateList);
        }
        public ActionResult SanPham()
        {
            var products = db.Products;
            return View(products.ToList());
        }
        public ActionResult Theloai2()
        {
            var products = db.Categories;
            return View(products.ToList());
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult View1()
        {
            var products = db.Products;
            return View(products.ToList());
        }
        public ActionResult Theloai3()
        {
            var products = db.Categories;
            return View(products.ToList());
        }
        public ActionResult Theloai3(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category product = db.Categories.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult timkiem(string seachBy, string seach)
        {
            if (seachBy == "NamePro")
                return View(db.Products.Where(s => s.NamePro.StartsWith(seach)).ToList());
            else if (seachBy == "DecriptionPro")
                return View(db.Products.Where(s => s.DecriptionPro == seach).ToList());
            else
                return View(db.Products.ToList());
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
        public ActionResult TrangChu0(string category, string SearchString, double min = double.MinValue, double max = double.MaxValue)
        { 
            //Tạo Product và có tham chiếu đến Category
            var products = db.Products.Include(p => p.Category);
            // Tìm kiếm chuỗi truy vấn theo Namepro, nếu chuỗi truy vấn SearchhString khách rỗng, null
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
            // Tìm kiếm chuỗi truy vấn the category
            if (category == null)
            {
                products = db.Products.OrderByDescending(x => x.NamePro);
            }
            else
            {
                products = db.Products.OrderByDescending(x => x.Category).Where(x => x.Category == category);
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
        public ActionResult TrangChuchinh(string category, string SearchString, double min = double.MinValue, double max = double.MaxValue)
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
        public ActionResult GioHang()
        {
            var products = db.Products;
            return View(products.ToList());
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
        public ActionResult Danhmuc()
        {
            var products = db.Products;
            return View(products.ToList());
        }

        public ActionResult Theloai()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Trangchu()
        {
            return View();
        }
        public ActionResult Trangchu2()
        {
            var products = db.Products;
            return View(products.ToList());
        }
        public ActionResult Đangnhap()
        {
            return View();
        }
        public ActionResult Đangky()
        {
            return View();
        }
        public ActionResult Nhomdich()
        {
            return View();
        }
        public ActionResult Lienhe()
        {
            return View();
        }
        public ActionResult Truyen_A_No()
        {
            return View();
        }
        public ActionResult Nhap()
        {
            return View();
        }
    }
}