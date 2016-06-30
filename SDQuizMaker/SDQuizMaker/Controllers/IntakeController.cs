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
    public class IntakeController : Controller
    {
        private Model1 db = new Model1();

        // GET: Intake
        public ActionResult Index()
        {
            var tbintakes = db.tbintakes.Include(t => t.tbprogram);
            return View(tbintakes.ToList());
        }

        // GET: Intake/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbintake tbintake = db.tbintakes.Find(id);
            if (tbintake == null)
            {
                return HttpNotFound();
            }
            return View(tbintake);
        }

        // GET: Intake/Create
        public ActionResult Create()
        {
            ViewBag.ProgramID = new SelectList(db.tbprograms, "ProgramID", "Name");
            return View();
        }

        // POST: Intake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,ProgramID")] tbintake tbintake)
        {
            if (ModelState.IsValid)
            {
                db.tbintakes.Add(tbintake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramID = new SelectList(db.tbprograms, "ProgramID", "Name", tbintake.ProgramID);
            return View(tbintake);
        }

        // GET: Intake/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbintake tbintake = db.tbintakes.Find(id);
            if (tbintake == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramID = new SelectList(db.tbprograms, "ProgramID", "Name", tbintake.ProgramID);
            return View(tbintake);
        }

        // POST: Intake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassID,ProgramID")] tbintake tbintake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbintake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramID = new SelectList(db.tbprograms, "ProgramID", "Name", tbintake.ProgramID);
            return View(tbintake);
        }

        // GET: Intake/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbintake tbintake = db.tbintakes.Find(id);
            if (tbintake == null)
            {
                return HttpNotFound();
            }
            return View(tbintake);
        }

        // POST: Intake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbintake tbintake = db.tbintakes.Find(id);
            db.tbintakes.Remove(tbintake);
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
