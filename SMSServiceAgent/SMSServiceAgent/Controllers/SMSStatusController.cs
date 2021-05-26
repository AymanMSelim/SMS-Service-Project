using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMSServiceAgent.Models;

namespace SMSServiceAgent.Controllers
{
    public class SMSStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SMSStatus
        public ActionResult Index()
        {
            return View(db.SMSStatuses.ToList());
        }

        // GET: SMSStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMSStatus sMSStatus = db.SMSStatuses.Find(id);
            if (sMSStatus == null)
            {
                return HttpNotFound();
            }
            return View(sMSStatus);
        }

        // GET: SMSStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMSStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status")] SMSStatus sMSStatus)
        {
            if (ModelState.IsValid)
            {
                db.SMSStatuses.Add(sMSStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMSStatus);
        }

        // GET: SMSStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMSStatus sMSStatus = db.SMSStatuses.Find(id);
            if (sMSStatus == null)
            {
                return HttpNotFound();
            }
            return View(sMSStatus);
        }

        // POST: SMSStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status")] SMSStatus sMSStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMSStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMSStatus);
        }

        // GET: SMSStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMSStatus sMSStatus = db.SMSStatuses.Find(id);
            if (sMSStatus == null)
            {
                return HttpNotFound();
            }
            return View(sMSStatus);
        }

        // POST: SMSStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            SMSStatus sMSStatus = db.SMSStatuses.Find(id);
            db.SMSStatuses.Remove(sMSStatus);
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
