using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeAn.Models;
using System.Data;
using System.IO;
using System.Net;
using System.Data.Entity;

namespace DeAn.Areas.Admin
{
    public class CategoryController : Controller
    {
        DBSportStoreEntities2 _db = new DBSportStoreEntities2();
        // GET: Admin/Category
        public ActionResult Index(string seachBy, string seach)
        {
            if (seachBy == "IDCate")
                return View(_db.Categories.Where(s => s.IDCate.StartsWith(seach)).ToList());
            else if (seachBy == "NameCate")
                return View(_db.Categories.Where(s => s.NameCate == seach).ToList());
            else
                return View(_db.Categories.ToList());
        }


        // GET: Admin/Category/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category product = _db.Categories.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            Category pro = new Category();
            return View(pro);
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            try
            {
                // TODO: Add insert logic here
                _db.Categories.Add(cate);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_db.Categories.Where(s => s.IDCate == id).FirstOrDefault());
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Category cate)
        {
            try
            {
                
                _db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(string id)
        {
            return View(_db.Categories.Where(s => s.IDCate == id).FirstOrDefault());
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Category cate)
        {


            try
            {
                
                // TODO: Add delete logic here
                cate = _db.Categories.Where(s => s.IDCate == id).FirstOrDefault();
                _db.Categories.Remove(cate);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            catch
            {
                return View();
            }


        }
    }
}
