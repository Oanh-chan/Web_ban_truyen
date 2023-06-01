using DeAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DeAn.Controllers
{
    public class CartController : Controller
    {
        DBSportStoreEntities2 _db = new DBSportStoreEntities2();
        public Cart1 GetCart()
        {

            Cart1 cart = Session["Cart"] as Cart1;
            // nếu bằng null
            if(cart == null || Session["Cart"] == null)
            {
                //tạo mới giỏ hàng
                cart = new Cart1();
                //gán vào session
                Session["Cart"] = cart;
            }
            return cart;
        }
        //thêm vào giỏ hàng
        // GET: Cart
       public ActionResult AddtoCart(int id)
        {
            //lấy từng sản phẩm bỏ vào trong giỏ hàng
            var pro = _db.Products.SingleOrDefault(s => s.ProductID == id);
            //nếu có sản phẩm
            if(pro != null)
            {
                //thêm sản phẩm vào giỏ hàng
                GetCart().Add(pro);

            }
            return RedirectToAction("ShowToCart", "Cart");
        }
        //Hiển thị giỏ hàng
        public ActionResult ShowToCart()
        {
            //nếu giỏ hàng trống
            if (Session["Cart"] == null)
                //điều hướng đến trang hiển thị giỏ hàng
                return RedirectToAction("ShowToCart", "Cart");
            //hiển thị giỏ hàng
            Cart1 cart = Session["Cart"] as Cart1;
            return View(cart);
        }
        
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            //tạo mới
            Cart1 cart = Session["Cart"] as Cart1;
            int id_pro = int.Parse(form["ID_Product"]);
            //lấy số lượng hiện tại gán cho Cart
            int quantity = int.Parse(form["Quantity"]);
            //update giỏ hàng
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "Cart");
        }
        // xóa danh mục trong giỏ hàng
       public ActionResult RemoveCart(int id)
        {
            
            Cart1 cart = Session["Cart"] as Cart1;
            //xóa theo id
            cart.Remove_CartItem(id);
            //load lại trang
            return RedirectToAction("ShowToCart", "Cart");
        }
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            Cart1 cart = Session["Cart"] as Cart1;
            
            if(cart != null)
            {
                _t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }
    }
}