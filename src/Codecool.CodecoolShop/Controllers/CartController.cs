using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using Codecool.CodecoolShop.Services;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Http;


namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        
        public static CartModel cart = new CartModel();
        public ProductService ProductService2 { get; set; }

        public static Order order = new Order();


        public IActionResult ShoppingCart()
        {
            var items = cart.GetContent();
            ViewData["dict"] = items;
            return View(ViewData["dict"]);
        }
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        public class Productdata
        {
            public List<Product> item { get; set; }
            
        }


        public IActionResult AddProductToCart(int productId)
        {
            ProductService2= new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());
            var items = ProductService2.GetProducts();
            var item = items.Where(s => s.Id == productId).ToList();
            cart.AddProduct(item[0]);
            return RedirectToAction("Index", "Product");
        }

        public IActionResult ChangeCart(int productId, bool grow, bool delete = false)
        {
            ProductService2 = new ProductService(
                    ProductDaoMemory.GetInstance(),
                    ProductCategoryDaoMemory.GetInstance());
            var items = ProductService2.GetProducts();
            var product = items.Where(s => s.Id == productId).ToList();
            
            if (grow == true && delete!= true)
            {
                cart.AddProduct(product[0]);
            }
            else if (grow == false && delete != true)
            {
                cart.RemoveProduct(product[0]);
            }
            else if (delete)
            {
                cart.DeleteKeyValue(product[0]);
            }
            return RedirectToAction("ShoppingCart");
        }

        public IActionResult ClearCart()
        {
            cart.ClearCart();
            return RedirectToAction("ShoppingCart");
        }

        
        public IActionResult CheckoutItems(int price)
        {
            
            order.GrowId(cart.GetContent());
            TempData["orderID"] = order.orderNumber;
            var strOrder = Newtonsoft.Json.JsonConvert.SerializeObject(new { OrderData = order});
            string strItems = "";
            foreach(var item in cart.GetContent().Keys)
            {
                strItems += Newtonsoft.Json.JsonConvert.SerializeObject(new { Item = item }) +"\n";
                strItems += Newtonsoft.Json.JsonConvert.SerializeObject(new { Amount = cart.GetContent()[item] }) + "\n";
            }
            
            HttpContext.Session.SetString("newOrder", strOrder);
            HttpContext.Session.SetString("newOrderItems", strItems);
            //  delete cart content
            cart.ClearCart();
            order.ClearOrder();
            return RedirectToAction("Checkout", "Checkout",new { shoppingCart = order, total = price });
        }
    }
}
