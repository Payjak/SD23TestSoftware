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
    public class TQuestionController : Controller
    {
        private Model1 db = new Model1();

        // GET: TQuestion
        public ActionResult Index()
        {
            var tbtquestions = db.tbtquestions.Include(t => t.tbtemplate);
            return View(tbtquestions.ToList());
        }

        // GET: TQuestion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtquestion tbtquestion = db.tbtquestions.Find(id);
            if (tbtquestion == null)
            {
                return HttpNotFound();
            }
            return View(tbtquestion);
        }

        // GET: TQuestion/Create
        public ActionResult Create()
        {
            ViewBag.TemplateID = new SelectList(db.tbtemplates, "TemplateID", "Name");
            return View();
        }

        // POST: TQuestion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TQuestionID,TemplateID,Question,Explanation")] tbtquestion tbtquestion)
        {
            if (ModelState.IsValid)
            {
                db.tbtquestions.Add(tbtquestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TemplateID = new SelectList(db.tbtemplates, "TemplateID", "Name", tbtquestion.TemplateID);
            return View(tbtquestion);
        }

        // GET: TQuestion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtquestion tbtquestion = db.tbtquestions.Find(id);
            if (tbtquestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.TemplateID = new SelectList(db.tbtemplates, "TemplateID", "Name", tbtquestion.TemplateID);
            return View(tbtquestion);
        }

        // POST: TQuestion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TQuestionID,TemplateID,Question,Explanation")] tbtquestion tbtquestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbtquestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TemplateID = new SelectList(db.tbtemplates, "TemplateID", "Name", tbtquestion.TemplateID);
            return View(tbtquestion);
        }

        // GET: TQuestion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtquestion tbtquestion = db.tbtquestions.Find(id);
            if (tbtquestion == null)
            {
                return HttpNotFound();
            }
            return View(tbtquestion);
        }

        // POST: TQuestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbtquestion tbtquestion = db.tbtquestions.Find(id);
            db.tbtquestions.Remove(tbtquestion);
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
