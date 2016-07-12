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
    public class TemplateController : Controller
    {
        private Model1 db = new Model1();

        // GET: Template
        public ActionResult Index()
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index","Home"); }
            return View(db.tbtemplates.ToList());
        }

        // GET: Template/Details/5
        public ActionResult Details(int? id)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtemplate tbtemplate = db.tbtemplates.Find(id);
            if (tbtemplate == null)
            {
                return HttpNotFound();
            }
            return View(tbtemplate);
        }

        // GET: Template/Create
        public ActionResult Create()
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // POST: Template/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TemplateID,Name")] tbtemplate tbtemplate)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (ModelState.IsValid)
            {
                db.tbtemplates.Add(tbtemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbtemplate);
        }

        // GET: Template/Edit/5
        public ActionResult Edit(int? id)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtemplate tbtemplate = db.tbtemplates.Find(id);
            if (tbtemplate == null)
            {
                return HttpNotFound();
            }
            return View(tbtemplate);
        }

        // POST: Template/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TemplateID,Name")] tbtemplate tbtemplate)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (ModelState.IsValid)
            {
                db.Entry(tbtemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbtemplate);
        }

        // GET: Template/Delete/5
        public ActionResult Delete(int? id)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtemplate tbtemplate = db.tbtemplates.Find(id);
            if (tbtemplate == null)
            {
                return HttpNotFound();
            }
            return View(tbtemplate);
        }

        // POST: Template/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            tbtemplate tbtemplate = db.tbtemplates.Find(id);
            db.tbtemplates.Remove(tbtemplate);
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
