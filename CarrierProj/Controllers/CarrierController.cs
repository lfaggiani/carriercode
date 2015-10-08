using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarrierProj.Models;
using CarrierProj.ViewModel;
using Microsoft.AspNet.Identity;

namespace CarrierProj.Controllers
{ 
    [Authorize] 
    public class CarrierController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carrier
        public ActionResult Index(string searchString)
        {
            string userID = User.Identity.GetUserId();

            var carriers = from c in db.Carriers
                           select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                carriers = carriers.Where(c => c.Name.Contains(searchString));
            }

            IQueryable < CarrierViewModel > data = from c in carriers
                                                   from ur in db.UserRatings
                                                   .Where(a => a.CarrierID == c.ID && a.ApplicationUserID == userID).DefaultIfEmpty()

                                                   from rt in db.Rates
                                                   .Where(rt => rt.ID == ur.RateID).DefaultIfEmpty()

                                                   select new CarrierViewModel()
                                                   {
                                                       ID = c.ID,
                                                       Code = c.Code,
                                                       Name = c.Name,
                                                       UserRatingID = ur.ID,
                                                       RateDescription = rt.Description
                                                   };
            //return View(db.Carriers.ToList());
            return View(data.ToList());
        }

        // GET: Carrier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carriers.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // GET: Carrier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,Name,CreatedDate")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                db.Carriers.Add(carrier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carrier);
        }

        // GET: Carrier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carriers.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // POST: Carrier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,Name,CreatedDate")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrier);
        }

        // GET: Carrier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carriers.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // POST: Carrier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrier carrier = db.Carriers.Find(id);
            db.Carriers.Remove(carrier);
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
