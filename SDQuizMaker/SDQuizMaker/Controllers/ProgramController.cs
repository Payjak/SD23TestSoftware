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
    public class ProgramController : Controller
    {
        private Model1 db = new Model1();

        // GET: Program
        public ActionResult Index()
        {
            return View(db.tbprograms.ToList());
        }

        // GET: Program/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbprogram tbprogram = db.tbprograms.Find(id);
            if (tbprogram == null)
            {
                return HttpNotFound();
            }
            return View(tbprogram);
        }

        // GET: Program/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Program/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramID,Name")] tbprogram tbprogram)
        {
            if (ModelState.IsValid)
            {
                db.tbprograms.Add(tbprogram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbprogram);
        }

        // GET: Program/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbprogram tbprogram = db.tbprograms.Find(id);
            if (tbprogram == null)
            {
                return HttpNotFound();
            }
            return View(tbprogram);
        }

        // POST: Program/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramID,Name")] tbprogram tbprogram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbprogram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbprogram);
        }

        // GET: Program/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbprogram tbprogram = db.tbprograms.Find(id);
            if (tbprogram == null)
            {
                return HttpNotFound();
            }
            return View(tbprogram);
        }

        // POST: Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbprogram tbprogram = db.tbprograms.Find(id);
            db.tbprograms.Remove(tbprogram);
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
