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
    public class TAnswerController : Controller
    {
        private Model1 db = new Model1();

        // GET: TAnswer
        public ActionResult Index()
        {
            var tbtanswers = db.tbtanswers.Include(t => t.tbtquestion);
            return View(tbtanswers.ToList());
        }

        // GET: TAnswer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtanswer tbtanswer = db.tbtanswers.Find(id);
            if (tbtanswer == null)
            {
                return HttpNotFound();
            }
            return View(tbtanswer);
        }

        // GET: TAnswer/Create
        public ActionResult Create()
        {
            ViewBag.TQuestionID = new SelectList(db.tbtquestions, "TQuestionID", "Question");
            return View();
        }

        // POST: TAnswer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TAnswerID,Text,Correct,TQuestionID")] tbtanswer tbtanswer)
        {
            if (ModelState.IsValid)
            {
                db.tbtanswers.Add(tbtanswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TQuestionID = new SelectList(db.tbtquestions, "TQuestionID", "Question", tbtanswer.TQuestionID);
            return View(tbtanswer);
        }

        // GET: TAnswer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtanswer tbtanswer = db.tbtanswers.Find(id);
            if (tbtanswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.TQuestionID = new SelectList(db.tbtquestions, "TQuestionID", "Question", tbtanswer.TQuestionID);
            return View(tbtanswer);
        }

        // POST: TAnswer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TAnswerID,Text,Correct,TQuestionID")] tbtanswer tbtanswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbtanswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TQuestionID = new SelectList(db.tbtquestions, "TQuestionID", "Question", tbtanswer.TQuestionID);
            return View(tbtanswer);
        }

        // GET: TAnswer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtanswer tbtanswer = db.tbtanswers.Find(id);
            if (tbtanswer == null)
            {
                return HttpNotFound();
            }
            return View(tbtanswer);
        }

        // POST: TAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbtanswer tbtanswer = db.tbtanswers.Find(id);
            db.tbtanswers.Remove(tbtanswer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
