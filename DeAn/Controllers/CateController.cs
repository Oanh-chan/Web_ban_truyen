using DeAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DeAn.Controllers
{
    public class CateController : Controller
    {
        DBSportStoreEntities2 db = new DBSportStoreEntities2();

        // GET: Catergory
        public ActionResult Index(string loai)
        {
            ViewBag.type = loai;
            return View();
        }
        
    // Action PartialViewResult
    [ChildActionOnly]
    public PartialViewResult CategoryPartial()
    {
        var cateList = db.Categories.ToList();
        return PartialView(cateList);
    }
    public ActionResult Loai(string loai)
        {
            ViewBag.type = loai;
            return View();
        }
        public ActionResult Catergory1(Category pro, Product n)
        {
            if (pro.IDCate == n.Category)
            {
                return RedirectToAction("Details","");
            }
            return View();
        }
        public ActionResult Listcat()
        {
            var list = db.Categories.Where(m => m.IDCate == null).ToList();
            return View("Listcat", list);
        }
    }
}