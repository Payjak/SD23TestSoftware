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
    public class tbiquestionsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbiquestions
        public ActionResult Index()
        {
            var tbiquestions = db.tbiquestions.Include(t => t.tbinstance);
            return View(tbiquestions.ToList());
        }

        // GET: tbiquestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbiquestion tbiquestion = db.tbiquestions.Find(id);
            if (tbiquestion == null)
            {
                return HttpNotFound();
            }
            return View(tbiquestion);
        }

        // GET: tbiquestions/Create
        public ActionResult Create()
        {
            ViewBag.InstanceID = new SelectList(db.tbinstances, "InstanceID", "UserID");
            return View();
        }

        // POST: tbiquestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IQuestionID,Question,Explanation,InstanceID")] tbiquestion tbiquestion)
        {
            if (ModelState.IsValid)
            {
                db.tbiquestions.Add(tbiquestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstanceID = new SelectList(db.tbinstances, "InstanceID", "UserID", tbiquestion.InstanceID);
            return View(tbiquestion);
        }

        // GET: tbiquestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbiquestion tbiquestion = db.tbiquestions.Find(id);
            if (tbiquestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstanceID = new SelectList(db.tbinstances, "InstanceID", "UserID", tbiquestion.InstanceID);
            return View(tbiquestion);
        }

        // POST: tbiquestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IQuestionID,Question,Explanation,InstanceID")] tbiquestion tbiquestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbiquestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstanceID = new SelectList(db.tbinstances, "InstanceID", "UserID", tbiquestion.InstanceID);
            return View(tbiquestion);
        }

        // GET: tbiquestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbiquestion tbiquestion = db.tbiquestions.Find(id);
            if (tbiquestion == null)
            {
                return HttpNotFound();
            }
            return View(tbiquestion);
        }

        // POST: tbiquestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbiquestion tbiquestion = db.tbiquestions.Find(id);
            db.tbiquestions.Remove(tbiquestion);
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
