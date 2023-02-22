using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private IEnumerable<Product> products;
        public ProductService ProductService { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());
        }

        // all products
        public IActionResult Index(string searchString, string searchCategory)
        {
            products = ProductService.GetProducts();
            //products = ProductService.GetProductsForCategory(1);
            //for (int i = 2; i< 14; i++)
            //{
            //    products =  products.Concat(ProductService.GetProductsForCategory(i));
            //}
            
            
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Supplier.Name.Contains(searchString));
                               
            }
            if (!string.IsNullOrEmpty(searchCategory))
            {
                products = products.Where(s => s.ProductCategory.Department.Contains(searchCategory));

            }


            return View(products.ToList());
        }

        //[HttpGet]
        //public ActionResult GetProduct(int productId)
        //{

        //    var items = ProductService.GetProducts();
        //    var item = items.Where(s => s.Id == productId).ToList();
        //    var strItem = Newtonsoft.Json.JsonConvert.SerializeObject(new { BaseModel = item });
        //    TempData["product"] = strItem;
        //    return RedirectToAction("AddProductToCart", "Cart");
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
