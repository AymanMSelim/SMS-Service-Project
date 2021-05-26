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
    [Authorize]
    public class SMSController : Controller
    {
        private ApplicationDbContext db = ApplicationDbContext.GetInstance();

        // GET: SMS
        public ActionResult Index()
        {
            string id = Helpers.CustomHelper.GetAuthenticatedUserId();
            return View(db.SMS.Where(u => u.UserId == id).ToList());
        }

        // GET: SMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMS sMS = db.SMS.Find(id);
            if (sMS == null)
            {
                return HttpNotFound();
            }
            return View(sMS);
        }

        // GET: SMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message")] SMS sMS)
        {
            if (ModelState.IsValid)
            {
                sMS.CreateAt = DateTime.Now;
                sMS.UserId = Helpers.CustomHelper.GetAuthenticatedUserId();
                var allCustomerList = db.Customers.Where(c => c.UserId == sMS.UserId).ToList();
                List<SMSSendingLog> sMSSendingLogs = new List<SMSSendingLog>();
                foreach (var customer in allCustomerList)
                {
                    sMSSendingLogs.Add(new SMSSendingLog
                    {
                        Customer = customer,
                        LastStatusChangeTime = DateTime.Now,
                        StatusId = 1,
                    });
                }
                sMS.SMSSendingLogs = new List<SMSSendingLog>();
                sMS.SMSSendingLogs.AddRange(sMSSendingLogs);
                db.SMS.Add(sMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMS);
        }

        // GET: SMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMS sMS = db.SMS.Find(id);
            if (sMS == null)
            {
                return HttpNotFound();
            }
            return View(sMS);
        }

        // POST: SMS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message,CreateAt")] SMS sMS)
        {
            sMS.UserId = Helpers.CustomHelper.GetAuthenticatedUserId();
            if (ModelState.IsValid)
            {
                db.Entry(sMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMS);
        }

        // GET: SMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMS sMS = db.SMS.Find(id);
            if (sMS == null)
            {
                return HttpNotFound();
            }
            return View(sMS);
        }

        // POST: SMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMS sMS = db.SMS.Find(id);
            db.SMS.Remove(sMS);
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
