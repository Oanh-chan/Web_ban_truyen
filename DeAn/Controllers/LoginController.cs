using DeAn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;

namespace DeAn.Controllers
{
    public class LoginController : Controller
    {
       DBSportStoreEntities2 database = new DBSportStoreEntities2();
        // GET: Login
        public ActionResult Index1()
        {
            return View(database.Customers.ToList());
        }
        public ActionResult Index2()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FormLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authen(Customer _user)
        {
            //Kiểm tra email và mật khẩu phải giống trong CSDL
            var check = database.Customers.Where(s => s. EmailCus.Equals(_user.EmailCus)&&s.PassCus.Equals(_user.PassCus)).FirstOrDefault();
            //nếu kiểm tra không trùng hoặc không có
            if (check == null)
            {
                //thông báo email hoặc mật khẩu sai
               _user.LoginErrorMessage="Email hoặc mật khẩu không đúng! Vui lòng thử lại!";

                return View("FormLogin", _user);
            }
            //nếu kiểm tra trùng khớp
            else
            {
                // hiện thông tin của người dùng
                Session["IDCus"] = _user.IDCus;
                //hiện thi email người dùng đăng nhập thành công
                Session["EmailCus"] = _user.EmailCus;
                //thành công sẽ dẫn đến trang chủ đăng nhập thành công
                return RedirectToAction("Trangchuchinh", "Home");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
               
                // Kiểm tra xem có người nào đăng ký với email đăng nhập này hay chưa
                var khachhang = database.Customers.FirstOrDefault(k => k.EmailCus == cust.EmailCus);
                //nếu chưa
                if (khachhang == null)
                { 
                    database.Configuration.ValidateOnSaveEnabled = true;
                    //thêm vào
                    database.Customers.Add(cust);
                    //save thay đổi
                    database.SaveChanges();
                    // dẫn đến đăng nhập
                    return RedirectToAction("FormLogin","Login");
                }
                // có rồi
                else
                {
                    // Xuất ra email đã tồn tại
                    ViewBag.error = "T đã tồn tại";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            //ghi đè lên lớp cơ sở và hủy session hiện tại
            Session.Abandon();
            //quay trở lại trang chủ khi chưa đăng nhập
            return RedirectToAction("TrangChu0", "Home");
        }
    }

    }


  