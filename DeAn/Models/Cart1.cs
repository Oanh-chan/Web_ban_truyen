using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeAn.Models
{
    public class CartItem
    {
        //sản phẩm
        public Product _shopping_product { get; set; }
        //số lượng
        public int _shopping_quantity { get; set; }
    }
    public class Cart1
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Product _pro, int _quantity = 1)
        {
            //lấy một sản phẩm dựa trên id của sản phẩm
            var item = items.FirstOrDefault(s => s._shopping_product.ProductID == _pro.ProductID);
            // nếu giỏ hàng trống
            if (item == null)
            {
                //sẽ thêm sp mới vào giỏ hàng
                items.Add(new CartItem
                {
                    _shopping_product = _pro,
                    // số lượng mua mới bằng số lượng hiện tại
                    _shopping_quantity = _quantity
                });
            }
            //nếu đã có rồi
            else
            {
                //thêm vào
                item._shopping_quantity += _quantity;
            }
            }
        //Số lượng giỏ hàng
        public void Update_Quantity_Shopping(int id, int _quantity)
        {
            //Tìm sản phẩm theo id và update lại
            var item = items.Find(s => s._shopping_product.ProductID == id);
            //nếu tồn tại
            if(item != null)
            {
                //lấy số lượng mới gán cho số lượng trước đó
                item._shopping_quantity = _quantity;
            }
        }
        //tính tổng tiền
        public double Total_Money()
        {
            var total = items.Sum(s => s._shopping_product.Price * s._shopping_quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._shopping_product.ProductID == id);
        }
        //tổng số lượng
        public int Total_Quantity()
        {
            //lấy các số lượng trên dòng cộng lại
            return items.Sum(s => s._shopping_quantity);
        }
    }
}