using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDQuizMaker.Models;

namespace SDQuizMaker.Controllers
{
    public class StudentQuizController : Controller
    {
        private Model1 db = new Model1();
        // GET: StudentQuiz
        public ActionResult Index()
        {

            var classid = (string)Session["ClassID"];
            var quiz = db.tbinstances.Include(i => i.tbintake).Where(t => t.ClassID == classid);
            if (quiz != null)
            {
                return View(quiz.ToList());
            }
            return RedirectToAction("Index", "Home");
        }
    }
}