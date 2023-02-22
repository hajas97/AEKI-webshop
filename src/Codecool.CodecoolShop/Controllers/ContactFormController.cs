using Microsoft.AspNetCore.Mvc;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.MailSystem;

namespace Codecool.CodecoolShop.Controllers
{
    public class ContactFormController : Controller
    {
        public IActionResult OnPost(ContactFormModel contForm)
        {
            string sName = contForm.SenderName;
            string sEmail = contForm.SenderEmail;
            string sSub = contForm.Subject;
            string sMessage = contForm.Message;
            // form-ból onclick-re kell meghívódnia

            MailSystem.MailSystem.SendEmail(sName,sEmail,sSub,sMessage,"AEKI automatic email");
            return RedirectToAction("ThankYouContact", "Home");
        }
    }
}
