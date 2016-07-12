using SDQuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

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
                Session["Email"] = us.Email;
                Session["AccessLevel"] = us.AccessLevel;
                Session["UserID"] = us.UserID;
                return RedirectToAction("Index", "Home");
            }
            else if (us.AccessLevel == "Mentor")
            {
                Session["Email"] = us.Email;
                Session["AccessLevel"] = us.AccessLevel;
                Session["UserID"] = us.UserID;
                return RedirectToAction("Index", "Home");
            }
            else if (us.AccessLevel == "Admin")
            {
                Session["Email"] = us.Email;
                Session["AccessLevel"] = us.AccessLevel;
                Session["UserID"] = us.UserID;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}