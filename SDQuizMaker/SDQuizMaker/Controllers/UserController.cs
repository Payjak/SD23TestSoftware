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
    public class UserController : Controller
    {
        private Model1 db = new Model1();

        // GET: User
        public ActionResult Index()
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            var amntofusers = db.tbusers.ToList().Count();
            Session["amntofusers"] = amntofusers + 1;
            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID");
            return View(db.tbusers.ToList());
        }

        public ActionResult Profile()
        {
            var id = Session["UserID"];
            tbuser tbuser = db.tbusers.Find(id);
            if (tbuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID");
            return View(tbuser);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbuser tbuser = db.tbusers.Find(id);
            if (tbuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID");
            return View(tbuser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,ClassID,ProfilePic,Email,Password,AccessLevel")] tbuser tbuser)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (ModelState.IsValid)
            {
                db.tbusers.Add(tbuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbuser);
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbuser tbuser = db.tbusers.Find(id);
            if (tbuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID");
            return View(tbuser);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,ClassID,ProfilePic,Email,Password,AccessLevel")] tbuser tbuser)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (ModelState.IsValid)
            {
                db.Entry(tbuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbuser);
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbuser tbuser = db.tbusers.Find(id);
            if (tbuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.tbintakes, "ClassID", "ClassID");
            return View(tbuser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if ((string)Session["Accesslevel"] != "Admin")
            { return RedirectToAction("Index", "Home"); }
            tbuser tbuser = db.tbusers.Find(id);
            db.tbusers.Remove(tbuser);
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
