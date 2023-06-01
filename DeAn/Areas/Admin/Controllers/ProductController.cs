using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeAn.Models;
using System.Data;
using System.IO;
using System.Net;

namespace DeAn.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        DBSportStoreEntities2 _database = new DBSportStoreEntities2();
        // GET: Admin/Product
        public ActionResult Index1(string seachBy, string seach)
        {
            //Tìm kiếm sản phẩm theo tên
            if (seachBy == "NamePro")
                return View(_database.Products.Where(s => s.NamePro.StartsWith(seach)).ToList());
            //tìm kiếm theo mô tả
            else if(seachBy == "DecriptionPro")
                return View(_database.Products.Where(s => s.DecriptionPro == seach).ToList());
            else
            return View(_database.Products.ToList());
        }

        // GET: Admin/Product/Details/5
        //Xem chi tiết sản phẩm
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _database.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        //Tạo mới sản phẩm
        public ActionResult Create()
        {
            
            Product pro = new Product();
            return View(pro);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                // TODO: Add insert logic here
                //Nếu khác null
                if (pro.ImageUpload != null)
                {
                    //lấy tên file lưu vào CSDL
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    //tên file + với đường dẫn
                    fileName = fileName + extension;
                    //lưu vào thư mục hình ảnh nối với tên file
                    pro.ImagePro = "~/images/" + fileName;
                    //lưu
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images"), fileName));
                }
                _database.Products.Add(pro);
                _database.SaveChanges();
                return RedirectToAction("Index1");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {
                // TODO: Add update logic here
                if (pro.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    fileName = fileName + extension;
                    pro.ImagePro = "~/images/" + fileName;
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images"), fileName));
                }
                //lưu thay đổi
                _database.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                _database.SaveChanges();
                return RedirectToAction("Index1");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            

            try
            {
                if (pro.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    fileName = fileName + extension;
                    pro.ImagePro = "~/images/" + fileName;
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images"), fileName));
                }
                // TODO: Add delete logic here
                pro = _database.Products.Where(s => s.ProductID == id).FirstOrDefault();
                _database.Products.Remove(pro);
                _database.SaveChanges();
                return RedirectToAction("Index1");
            }
            catch
            {
                return View();
            }
           
           
        }
        public ActionResult ChoseCategory()
        {
            Category cate = new Category();
            cate.CateCollectionP = _database.Categories.ToList<Category>();
            return PartialView(cate);
        }
    }
}
