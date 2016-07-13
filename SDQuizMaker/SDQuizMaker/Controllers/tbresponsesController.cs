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
    public class tbresponsesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbresponses
        public ActionResult Index()
        {
            var tbresponses = db.tbresponses.Include(t => t.tbinstance).Include(t => t.tbuser);
            return View(tbresponses.ToList());
        }

        // GET: tbresponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbresponse tbresponse = db.tbresponses.Find(id);
            if (tbresponse == null)
            {
                return HttpNotFound();
            }
            return View(tbresponse);
        }

        // GET: tbresponses/Create
        public ActionResult Create()
        {
            ViewBag.InstanceID = new SelectList(db.tbinstances, "InstanceID", "UserID");
            ViewBag.UserID = new SelectList(db.tbusers, "UserID", "Email");
            return View();
        }

        // POST: tbresponses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResponseID,Score,UserID,InstanceID")] tbresponse tbresponse)
        {
            if (ModelState.IsValid)
            {
                db.tbresponses.Add(tbresponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstanceID = new SelectList(db.tbinstances, "InstanceID", "UserID", tbresponse.InstanceID);
            ViewBag.UserID = new SelectList(db.tbusers, "UserID", "Email", tbresponse.UserID);
            return View(tbresponse);
        }

        // GET: tbresponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbresponse tbresponse = db.tbresponses.Find(id);
            if (tbresponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstanceID = new SelectList(db.tbinstances, "InstanceID", "UserID", tbresponse.InstanceID);
            ViewBag.UserID = new SelectList(db.tbusers, "UserID", "Email", tbresponse.UserID);
            return View(tbresponse);
        }

        // POST: tbresponses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResponseID,Score,UserID,InstanceID")] tbresponse tbresponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbresponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstanceID = new SelectList(db.tbinstances, "InstanceID", "UserID", tbresponse.InstanceID);
            ViewBag.UserID = new SelectList(db.tbusers, "UserID", "Email", tbresponse.UserID);
            return View(tbresponse);
        }

        // GET: tbresponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbresponse tbresponse = db.tbresponses.Find(id);
            if (tbresponse == null)
            {
                return HttpNotFound();
            }
            return View(tbresponse);
        }

        // POST: tbresponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbresponse tbresponse = db.tbresponses.Find(id);
            db.tbresponses.Remove(tbresponse);
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
