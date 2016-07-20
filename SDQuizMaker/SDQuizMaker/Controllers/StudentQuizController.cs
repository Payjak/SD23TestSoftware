using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDQuizMaker.Controllers
{
    public class StudentQuizController : Controller
    {
        // GET: StudentQuiz
        public ActionResult Index()
        {
            return View();
        }
    }
}