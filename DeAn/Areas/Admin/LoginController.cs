using DeAn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeAn.Areas.Admin
{
    public class LoginController : Controller
    {
        DBSportStoreEntities2 database = new DBSportStoreEntities2();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View(database.AdminUsers.ToList());
        }
        public ActionResult FormLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authen(AdminUser _user)
        {
            var check = database.AdminUsers.Where(s => s.RoleUser.Equals(_user.RoleUser) && s.PasswordUser.Equals(_user.PasswordUser)).FirstOrDefault();
            if (check == null)
            {
                _user.LoginErrorMessage = "Tên hoặc mật khẩu không đúng! Vui lòng thử lại!";

                return View("FormLogin", _user);
            }
            else
            {

                Session["ID"] = _user.ID;
                Session["NameUser"] = _user.NameUser;
                Session["RoleUser"] = _user.RoleUser;
                return RedirectToAction("Index1", "Product");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminUser cust)
        {
            if (ModelState.IsValid)
            {

                // Kiểm tra xem có người nào đăng ký với tên đăng nhập này hay chưa
                var khachhang = database.AdminUsers.FirstOrDefault(k => k.NameUser == cust.NameUser);
                if (khachhang == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.AdminUsers.Add(cust);
                    database.SaveChanges();
                    return RedirectToAction("FormLogin", "Login");
                }

                else
                {
                    ViewBag.error = "Tên đã tồn tại";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("FormLogin", "Login");
        }
    }
}