using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Codecool.CodecoolShop.Controllers
{
    public class CheckoutController : Controller
    {
        public Order order;
        // display checkout page
        //public IActionResult Checkout(CartModel shoppingcart,int userId = 0)
        //{
        //    var orderedProducts = shoppingcart.GetContent();

        //    // guest login
        //    if (userId == 0)
        //    {
        //        order = new Order(orderedProducts);
        //    }
        //    else
        //    {
        //       order = new Order(orderedProducts, userId);
        //    }
        //    return View();
        //}

        public IActionResult Checkout(CartModel shoppingCart,int total, int userId = 0)
        {

            
            // guest login
            if (userId == 0)
            {
               
            }
            else
            {
               
            }
            TempData["totalPrice"] = total;
            return View("Checkout");
        }

        // checkout items

        public IActionResult Pay(CheckoutFormModel checkForm)
        {
            var orderNum = TempData["orderID"];
            var orderStr = HttpContext.Session.GetString("newOrder");
            var orderDate = DateTime.Now.ToString("yyyy/MM/dd");
            var orderItemsStr = HttpContext.Session.GetString("newOrderItems");
            orderStr = $"{orderStr}\n{orderItemsStr}";
            try 
            {
                System.IO.File.WriteAllText($@"Logging\Orders\{orderDate}_Order_{orderNum}.json", orderStr);
            }
            catch 
            {
                throw new System.Exception();
            }
            
            
            string sSub = $"Order comfirmation";
            var OrderName = checkForm.OrderName;
            var OrderEmail = checkForm.OrderEmail;
            var OrderedItems = orderItemsStr;
            
            string sMessage = $"Order Number: {orderNum}\nOrder content:\n {orderItemsStr}";
            //// form-ból onclick-re kell meghívódnia

            MailSystem.MailSystem.SendEmail(OrderName, OrderEmail, sSub, sMessage, "AEKI automatic email",true);
            return RedirectToAction("ThanksYourOrder","Home");
        }
    }
}
