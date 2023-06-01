using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeAn.Models;

namespace DeAn.Controllers
{
    
    public class TiemKiemController : Controller
    {
        DBSportStoreEntities2 db = new DBSportStoreEntities2();
        // GET: TiemKiem
        public ActionResult KQTiemKiem(string sTuKhoa)
        {
            var lstSP = db.Products.Where(n => n.NamePro.Contains(sTuKhoa));
            return View(lstSP.OrderBy(n => n.NamePro));
        }
    }
}