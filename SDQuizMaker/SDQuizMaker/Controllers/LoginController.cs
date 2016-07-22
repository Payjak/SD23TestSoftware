using SDQuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Threading.Tasks;
using System.Globalization;



namespace SDQuizMaker.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ForgotPassword(Login obj)
        {

            try
            {
                Model1 db = new Model1();
                var user = db.tbusers.FirstOrDefault(m => (m.Email == obj.Email));
                var password = user.Password;
                var email = user.Email;
                MailMessage myMessage = new MailMessage();
                myMessage.From = new MailAddress(email.ToString());
                myMessage.To.Add(new MailAddress(email.ToString()));
                myMessage.Subject = "";
                myMessage.Body = password.ToString();
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;


                client.Credentials = new System.Net.NetworkCredential
                    (email, password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(myMessage);
                TempData["recovsuccess"] = "<script>alert('Password recovery successful, your password has been sent to your email. Click Login to sign-in again');</script>";

            }

            catch

            {
                TempData["msg"] = "<script>alert('Incorrect Credentials. Please check your email address.');</script>";
            }

            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login obj)
        {
            Model1 db = new Model1();
            var us = db.tbusers.FirstOrDefault(m => (m.Email == obj.Email) && m.Password == obj.Password);
            if (us == null)
            {
                TempData["msg"] = "<script>alert('Wrong Email Or Password');</script>";
            }
            else if (us.AccessLevel == "Student")
            {
                Session["ProfilePic"] = us.ProfilePic;
                Session["Email"] = us.Email;
                Session["AccessLevel"] = us.AccessLevel;
                Session["UserID"] = us.UserID;
                Session["ClassID"] = us.ClassID;

                var classid = (string)Session["ClassID"];
                var quiz = db.tbinstances.Where(t => t.ClassID == classid);
                var chk = quiz.ToList().Count();
                Session["chk"] = chk; 


                return RedirectToAction("Index", "Home");
            }
            else if (us.AccessLevel == "Mentor")
            {
                Session["ProfilePic"] = us.ProfilePic;
                Session["Email"] = us.Email;
                Session["AccessLevel"] = us.AccessLevel;
                Session["UserID"] = us.UserID;
                return RedirectToAction("Index", "Home");
            }
            else if (us.AccessLevel == "Admin")
            {
                Session["ClassID"] = us.ClassID;
                Session["ProfilePic"] = us.ProfilePic;
                Session["Email"] = us.Email;
                Session["AccessLevel"] = us.AccessLevel;
                Session["UserID"] = us.UserID;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}