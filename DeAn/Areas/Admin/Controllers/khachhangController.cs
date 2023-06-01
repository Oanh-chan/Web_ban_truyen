using DeAn.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DeAn.Areas.Admin.Controllers
{
    public class khachhangController : Controller
    {
        DBSportStoreEntities2 _database = new DBSportStoreEntities2();
        // GET: Admin/Product
        public ActionResult Index(string seachBy, string seach)
        {
            if (seachBy == "NameCus")
                return View(_database.Customers.Where(s => s.NameCus.StartsWith(seach)).ToList());
            else if (seachBy == "EmailCus")
                return View(_database.Customers.Where(s => s.EmailCus == seach).ToList());
            else
                return View(_database.Customers.ToList());
        }
        public ActionResult Details(int id)
        {
            return View(_database.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }
        // GET: Admin/khachhang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer product = _database.Customers.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/khachhang/Create
        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            Customer pro = new Customer();
            return View(pro);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Customer cust)
        {
            try
            {
                // TODO: Add insert logic here
                
                _database.Customers.Add(cust);
                _database.SaveChanges();
                return RedirectToAction("Index", "khachhang");
            }
            catch
            {
                return View();
            }
        }


        // GET: Admin/khachhang/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_database.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer pro)
        {
            try
            {
                // TODO: Add update logic here
                
                _database.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                _database.SaveChanges();
                return RedirectToAction("Index", "khachhang");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/khachhang/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_database.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }

        // POST: Admin/khachhang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,  Customer pro)
        {
            try
            {
                pro = _database.Customers.Where(s => s.IDCus == id).FirstOrDefault();
                _database.Customers.Remove(pro);
                _database.SaveChanges();
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
