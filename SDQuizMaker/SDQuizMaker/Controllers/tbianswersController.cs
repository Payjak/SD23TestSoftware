using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDQuizMaker.Models;

namespace SDQuizMaker
{
    public class tbianswersController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbianswers
        public ActionResult Index()
        {
            var tbianswers = db.tbianswers.Include(t => t.tbiquestion);
            return View(tbianswers.ToList());
        }

        // GET: tbianswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbianswer tbianswer = db.tbianswers.Find(id);
            if (tbianswer == null)
            {
                return HttpNotFound();
            }
            return View(tbianswer);
        }

        // GET: tbianswers/Create
        public ActionResult Create()
        {
            ViewBag.IQuestionID = new SelectList(db.tbiquestions, "IQuestionID", "Question");
            return View();
        }

        // POST: tbianswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IAnswerID,Text,Correct,IQuestionID")] tbianswer tbianswer)
        {
            if (ModelState.IsValid)
            {
                db.tbianswers.Add(tbianswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IQuestionID = new SelectList(db.tbiquestions, "IQuestionID", "Question", tbianswer.IQuestionID);
            return View(tbianswer);
        }

        // GET: tbianswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbianswer tbianswer = db.tbianswers.Find(id);
            if (tbianswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.IQuestionID = new SelectList(db.tbiquestions, "IQuestionID", "Question", tbianswer.IQuestionID);
            return View(tbianswer);
        }

        // POST: tbianswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IAnswerID,Text,Correct,IQuestionID")] tbianswer tbianswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbianswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IQuestionID = new SelectList(db.tbiquestions, "IQuestionID", "Question", tbianswer.IQuestionID);
            return View(tbianswer);
        }

        // GET: tbianswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbianswer tbianswer = db.tbianswers.Find(id);
            if (tbianswer == null)
            {
                return HttpNotFound();
            }
            return View(tbianswer);
        }

        // POST: tbianswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbianswer tbianswer = db.tbianswers.Find(id);
            db.tbianswers.Remove(tbianswer);
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
