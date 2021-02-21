using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Geek_Inside.Models;
namespace Geek_Inside.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(HomeModel model )
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("srjej156@gmail.com");
            mail.From = new MailAddress("eliasplaying@gmail.com");
            mail.Subject = "Mensaje de " + model.Name+ " - " + model.Phone;
            mail.Body = model.Message;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("eliasplaying@gmail.com", "bueno1234"); 
            smtp.Send(mail);
            //return RedirectToAction("Contact","Home");
            return View();
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}