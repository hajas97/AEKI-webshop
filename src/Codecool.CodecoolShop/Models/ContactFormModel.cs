using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Codecool.CodecoolShop.Models
{
    
    [BindProperties]
    public class ContactFormModel
    {
        private string senderName;
        private string senderEmail;
        private string subject;
        private string message;

        [Required]
        public string SenderName { get => senderName; set => senderName = value; }
        [Required]
        public string SenderEmail { get => senderEmail; set => senderEmail = value; }
        [Required]
        public string Subject { get => subject; set => subject = value; }
        public string Message { get => message; set => message = value; }
    }
}
