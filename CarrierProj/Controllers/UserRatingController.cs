using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarrierProj.Models;
using Microsoft.AspNet.Identity;

namespace CarrierProj.Controllers
{
    [Authorize]
    public class UserRatingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserRating
        public ActionResult Index()
        {
            var userRatings = db.UserRatings.Include(u => u.ApplicationUser).Include(u => u.Carrier).Include(u => u.Rate);
            return View(userRatings.ToList());
        }

        // GET: UserRating/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = db.UserRatings.Find(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View(userRating);
        }

        // GET: UserRating/Create
        public ActionResult Create(int carrierID)
        {
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email", User.Identity.GetUserId());
            ViewBag.CarrierID = new SelectList(db.Carriers, "ID", "Name", carrierID);
            ViewBag.RateID = new SelectList(db.Rates, "ID", "Description");
            return View();
        }

        // POST: UserRating/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "ApplicationUserID")] UserRating userRating)
        {
            userRating.ApplicationUserID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.UserRatings.Add(userRating);
                db.SaveChanges();
                return RedirectToAction("Index", "Carrier");
            }

            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email", userRating.ApplicationUserID);
            ViewBag.CarrierID = new SelectList(db.Carriers, "ID", "Code", userRating.CarrierID);
            ViewBag.RateID = new SelectList(db.Rates, "ID", "Description", userRating.RateID);
            return View(userRating);
        }

        // GET: UserRating/Edit/5
        public ActionResult Edit(int? id, int carrierID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = db.UserRatings.Find(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email", userRating.ApplicationUserID);
            ViewBag.CarrierID = new SelectList(db.Carriers, "ID", "Name", userRating.CarrierID);
            ViewBag.RateID = new SelectList(db.Rates, "ID", "Description", userRating.RateID);
            return View(userRating);
        }

        // POST: UserRating/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "ApplicationUserID")] UserRating userRating)
        {
            userRating.ApplicationUserID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.Entry(userRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Carrier");
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email", userRating.ApplicationUserID);
            ViewBag.CarrierID = new SelectList(db.Carriers, "ID", "Code", userRating.CarrierID);
            ViewBag.RateID = new SelectList(db.Rates, "ID", "Description", userRating.RateID);
            return View(userRating);
        }

        // GET: UserRating/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = db.UserRatings.Find(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View(userRating);
        }

        // POST: UserRating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRating userRating = db.UserRatings.Find(id);
            db.UserRatings.Remove(userRating);
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
