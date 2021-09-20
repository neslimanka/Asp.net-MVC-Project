using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TabimApplication.Models.DataContext;
using TabimApplication.Models.Model;

namespace TabimApplication.Controllers
{
    public class SendEmailController : Controller
    {
        TabimDBContext db = new TabimDBContext();



        public ActionResult Index()
        {
            return View();
        }


       
        [HttpPost]
        public ActionResult Index( Contact contact,Request request=null)
        {

            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Ad & Soyad: " + contact.Name);
                body.AppendLine("E-Mail Adresi: " + contact.Email);
                body.AppendLine("Konu: " + contact.Subject);
                body.AppendLine("Mesaj: " + contact.Message);
                string mail = contact.ReceiveMail;
                Mail.MailSender(body.ToString(), mail);
            }
            return View();
        }
    }
}