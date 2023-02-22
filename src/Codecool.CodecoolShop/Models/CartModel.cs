using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Codecool.CodecoolShop.Models
{
    public class CartModel
    {
        public Dictionary<Product, int> Products = new Dictionary<Product, int>();

        public CartModel()
        {

        }
        public void AddProduct(Product product)
        {

            if ((product == null) || (product.Name==null))
            {
                throw new ArgumentNullException();
            }
            
            else if(Products.ContainsKey(product))
            {
                this.Products[product] += 1;
            }
            else
            {
                this.Products.Add(product, 1);
            }
        }

        public void RemoveProduct(Product product)
        {

            if ((product == null) || (product.Name == null))
            {
                throw new ArgumentNullException();
            }

            else if (Products.ContainsKey(product))
            {
                if (this.Products[product] > 1)
                {
                    this.Products[product] -= 1;
                }
                else
                {
                    //this.Products.Remove(product);
                    
                }
               
            }
           
        }

        public void DeleteKeyValue(Product product)
        {
            this.Products[product] = 0;
            this.Products.Remove(product);
        }

        public Dictionary<Product, int> GetContent() 
        {
            return this.Products;
        }
        public void ClearCart()
        {
            this.Products.Clear();
        }
    }
}
