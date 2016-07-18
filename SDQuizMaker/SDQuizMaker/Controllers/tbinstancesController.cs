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
    public class tbinstancesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbinstances
        public ActionResult Index()
        {
            var tbinstances = db.tbinstances.Include(t => t.tbintake);
            return View(tbinstances.ToList());
        }

        // GET: tbinstances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbinstance tbinstance = db.tbinstances.Find(id);
            if (tbinstance == null)
            {
                return HttpNotFound();
            }
            return View(tbinstance);
        }

        // GET: tbinstances/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID");
            ViewBag.TemplateID = new SelectList(db.tbtemplates, "TemplateID", "Name");
            return View();
        }

        // POST: tbinstances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstanceID,StartTime,EndTime,UserID,ClassID,TemplateID")] tbinstance tbinstance)
        {
            if (ModelState.IsValid)
            {
                db.tbinstances.Add(tbinstance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID", tbinstance.ClassID);
            ViewBag.TemplateID = new SelectList(db.tbtemplates, "TemplateID", "Name", tbinstance.TemplateID);
            return View(tbinstance);
        }

        // GET: tbinstances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbinstance tbinstance = db.tbinstances.Find(id);
            if (tbinstance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID", tbinstance.ClassID);
            return View(tbinstance);
        }

        // POST: tbinstances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstanceID,StartTime,EndTime,UserID,ClassID")] tbinstance tbinstance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbinstance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID", tbinstance.ClassID);
            return View(tbinstance);
        }

        // GET: tbinstances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbinstance tbinstance = db.tbinstances.Find(id);
            if (tbinstance == null)
            {
                return HttpNotFound();
            }
            return View(tbinstance);
        }

        // POST: tbinstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbinstance tbinstance = db.tbinstances.Find(id);
            db.tbinstances.Remove(tbinstance);
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
