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
    public class tbresponsedetailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbresponsedetails
        public ActionResult Index()
        {
            var tbresponsedetails = db.tbresponsedetails.Include(t => t.tbianswer).Include(t => t.tbresponse);
            return View(tbresponsedetails.ToList());
        }

        // GET: tbresponsedetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbresponsedetail tbresponsedetail = db.tbresponsedetails.Find(id);
            if (tbresponsedetail == null)
            {
                return HttpNotFound();
            }
            return View(tbresponsedetail);
        }

        // GET: tbresponsedetails/Create
        public ActionResult Create()
        {
            ViewBag.IAnswerID = new SelectList(db.tbianswers, "IAnswerID", "Text");
            ViewBag.ResponseID = new SelectList(db.tbresponses, "ResponseID", "UserID");
            return View();
        }

        // POST: tbresponsedetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetailID,ResponseID,IAnswerID")] tbresponsedetail tbresponsedetail)
        {
            if (ModelState.IsValid)
            {
                db.tbresponsedetails.Add(tbresponsedetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IAnswerID = new SelectList(db.tbianswers, "IAnswerID", "Text", tbresponsedetail.IAnswerID);
            ViewBag.ResponseID = new SelectList(db.tbresponses, "ResponseID", "UserID", tbresponsedetail.ResponseID);
            return View(tbresponsedetail);
        }

        // GET: tbresponsedetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbresponsedetail tbresponsedetail = db.tbresponsedetails.Find(id);
            if (tbresponsedetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IAnswerID = new SelectList(db.tbianswers, "IAnswerID", "Text", tbresponsedetail.IAnswerID);
            ViewBag.ResponseID = new SelectList(db.tbresponses, "ResponseID", "UserID", tbresponsedetail.ResponseID);
            return View(tbresponsedetail);
        }

        // POST: tbresponsedetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetailID,ResponseID,IAnswerID")] tbresponsedetail tbresponsedetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbresponsedetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IAnswerID = new SelectList(db.tbianswers, "IAnswerID", "Text", tbresponsedetail.IAnswerID);
            ViewBag.ResponseID = new SelectList(db.tbresponses, "ResponseID", "UserID", tbresponsedetail.ResponseID);
            return View(tbresponsedetail);
        }

        // GET: tbresponsedetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbresponsedetail tbresponsedetail = db.tbresponsedetails.Find(id);
            if (tbresponsedetail == null)
            {
                return HttpNotFound();
            }
            return View(tbresponsedetail);
        }

        // POST: tbresponsedetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbresponsedetail tbresponsedetail = db.tbresponsedetails.Find(id);
            db.tbresponsedetails.Remove(tbresponsedetail);
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
