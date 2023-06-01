using DeAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeAn.Controllers
{
    public class CTController : Controller
    {
        DBSportStoreEntities2 db = new DBSportStoreEntities2();
        // GET: CT
        public ActionResult Index()
        {
            return View();
        }
        // Action PartialViewResult
        [ChildActionOnly]
        public PartialViewResult CategoryPartial()
        {
            var cateList = db.Categories.ToList();
            return PartialView(cateList);
        }
    }
}