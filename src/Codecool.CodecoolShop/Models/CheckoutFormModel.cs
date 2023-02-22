using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    [BindProperties]
    public class CheckoutFormModel
    {
        private string orderName;
        private string orderEmail;
        [Required]
        public string OrderName { get => orderName; set => orderName = value; }
        [Required]
        public string OrderEmail { get => orderEmail; set => orderEmail = value; }
    }
}
