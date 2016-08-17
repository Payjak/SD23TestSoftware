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

        public ActionResult TakingTest()
        {
            Random random = new Random();
            Session["choosetestid"] = (string)HttpContext.Request.RequestContext.RouteData.Values["id"];
            var choosetestid = Session["choosetestid"];
            var questions = db.tbtquestions.Include(t => t.tbtemplate);
            int templateid = int.Parse(choosetestid.ToString());
            var temp = db.tbtemplates.FirstOrDefault(t => t.TemplateID == templateid);
            Session["tempname"] = temp.Name;
            return View(questions.ToList().Where(t => t.TemplateID == Convert.ToInt32(choosetestid)).OrderBy(r => random.Next()));
        }


        public ActionResult TestAnswers()
        {
            Random random = new Random();
            Session["choosequestionid"] = (string)HttpContext.Request.RequestContext.RouteData.Values["id"];
            var chooseq = Session["choosequestionid"];
            var answers = db.tbtanswers.Include(q => q.tbtquestion);
            return View(answers.ToList().Where(q => q.TQuestionID == Convert.ToInt32(chooseq)).OrderBy(r => random.Next()));
        }
    }
}