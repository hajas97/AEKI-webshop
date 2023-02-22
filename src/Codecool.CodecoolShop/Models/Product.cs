using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class Product : BaseModel
    {
        [JsonProperty("Currency")]
        public string Currency { get; set; }
        
        [JsonProperty("DefaultPrice")]
        public decimal DefaultPrice { get; set; }

        [JsonProperty("ProductCategory")]
        public ProductCategory ProductCategory { get; set; }

        [JsonProperty("Supplier")]
        public Supplier Supplier { get; set; }


        //public override string ToString() => JsonSerializer.Serialize<Product>(this)
        public void SetProductCategory(ProductCategory productCategory)
        {
            ProductCategory = productCategory;
            ProductCategory.Products.Add(this);
        }
    }
}
