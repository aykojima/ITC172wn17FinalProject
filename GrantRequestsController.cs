using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class GrantRequestsController : Controller
    {
        private Community_AssistEntities db = new Community_AssistEntities();

        // GET: GrantRequests
        public ActionResult Index()
        {
            var grantRequest = db.GrantRequest.Include(g => g.GrantType).Include(g => g.Person);
            return View(grantRequest.ToList());
        }

        // GET: GrantRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantRequest grantRequest = db.GrantRequest.Find(id);
            if (grantRequest == null)
            {
                return HttpNotFound();
            }
            return View(grantRequest);
        }

        // GET: GrantRequests/Create
        public ActionResult Create()
        {
            ViewBag.GrantTypeKey = new SelectList(db.GrantType, "GrantTypeKey", "GrantTypeName");
            ViewBag.PersonKey = new SelectList(db.Person, "PersonKey", "PersonLastName");
            return View();
        }

        // POST: GrantRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrantRequestDate,PersonKey,GrantTypeKey,GrantRequestExplanation,GrantRequestAmount")] GrantRequest grantRequest)
        {
            if (ModelState.IsValid)
            {
                //db.GrantRequest.Add(grantRequest);
                //db.SaveChanges();
                db.usp_AddRequest(
                   grantRequest.GrantTypeKey,
                   grantRequest.GrantRequestExplanation,
                   grantRequest.GrantRequestAmount,
                   grantRequest.PersonKey
                    );

                return RedirectToAction("Index");
            }

            ViewBag.GrantTypeKey = new SelectList(db.GrantType, "GrantTypeKey", "GrantTypeName", grantRequest.GrantTypeKey);
            ViewBag.PersonKey = new SelectList(db.Person, "PersonKey", "PersonLastName", grantRequest.PersonKey);
            return View(grantRequest);
        }

        // GET: GrantRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantRequest grantRequest = db.GrantRequest.Find(id);
            if (grantRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrantTypeKey = new SelectList(db.GrantType, "GrantTypeKey", "GrantTypeName", grantRequest.GrantTypeKey);
            ViewBag.PersonKey = new SelectList(db.Person, "PersonKey", "PersonLastName", grantRequest.PersonKey);
            return View(grantRequest);
        }

        // POST: GrantRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrantRequestKey,GrantRequestDate,PersonKey,GrantTypeKey,GrantRequestExplanation,GrantRequestAmount")] GrantRequest grantRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grantRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrantTypeKey = new SelectList(db.GrantType, "GrantTypeKey", "GrantTypeName", grantRequest.GrantTypeKey);
            ViewBag.PersonKey = new SelectList(db.Person, "PersonKey", "PersonLastName", grantRequest.PersonKey);
            return View(grantRequest);
        }

        // GET: GrantRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantRequest grantRequest = db.GrantRequest.Find(id);
            if (grantRequest == null)
            {
                return HttpNotFound();
            }
            return View(grantRequest);
        }

        // POST: GrantRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrantRequest grantRequest = db.GrantRequest.Find(id);
            db.GrantRequest.Remove(grantRequest);
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
