using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Codecool.CodecoolShop.Models
{ 
    public class Order : BaseModel
    {
        private Dictionary<int, Dictionary<Product, int>> products = new Dictionary<int, Dictionary<Product, int>>();
        public int orderNumber { get; set; } 
        public int userId { get; set; }

        public Order()
        {

        }
        // guest order
        public Order(Dictionary<Product, int> products)
        {
            orderNumber += 1;
            this.products.Add(orderNumber, products);
            
        }

        // logged-in user's order
        public Order(Dictionary<Product, int> products, int userId)
        {
            orderNumber += 1;
            this.products.Add(orderNumber, products);
            this.userId = userId;
        }

        public void LogOrder()
        {
            //this.products >> json
        }
        public void ClearOrder()
        {
            this.products.Clear();
        }
        public void GrowId(Dictionary<Product, int> products)
        {
            orderNumber += 1;
            this.products.Add(orderNumber, products);
        }
    }
}
