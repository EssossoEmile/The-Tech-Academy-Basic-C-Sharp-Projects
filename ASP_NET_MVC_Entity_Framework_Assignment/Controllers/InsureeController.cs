using CarInsurance.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null) return HttpNotFound();
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,SpeedingTickets,DUI,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // BASE
                decimal quote = 50m;

                // AGE calculation (accurate)
                DateTime today = DateTime.Today;
                int age = today.Year - insuree.DateOfBirth.Year;
                if (insuree.DateOfBirth > today.AddYears(-age)) age--;

                // Age-based rules
                if (age <= 18)
                {
                    quote += 100m;
                }
                else if (age >= 19 && age <= 25)
                {
                    quote += 50m;
                }
                else // 26 or older covers all remaining ages
                {
                    quote += 25m;
                }

                // Car year rules
                if (insuree.CarYear < 2000)
                {
                    quote += 25m;
                }
                if (insuree.CarYear > 2015)
                {
                    quote += 25m;
                }

                // Make and model
                if (!string.IsNullOrWhiteSpace(insuree.CarMake) &&
                    insuree.CarMake.Equals("Porsche", StringComparison.OrdinalIgnoreCase))
                {
                    quote += 25m;
                    if (!string.IsNullOrWhiteSpace(insuree.CarModel) &&
                        insuree.CarModel.Equals("911 Carrera", StringComparison.OrdinalIgnoreCase))
                    {
                        quote += 25m; // additional for 911 Carrera (total +50 for this car)
                    }
                }

                // Speeding tickets
                if (insuree.SpeedingTickets > 0)
                {
                    quote += insuree.SpeedingTickets * 10m;
                }

                // DUI: add 25%
                if (insuree.DUI)
                {
                    quote += quote * 0.25m;
                }

                // Full coverage: add 50%
                if (!string.IsNullOrWhiteSpace(insuree.CoverageType) &&
                    insuree.CoverageType.Equals("Full", StringComparison.OrdinalIgnoreCase))
                {
                    quote += quote * 0.50m;
                }

                insuree.Quote = Math.Round(quote, 2);

                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null) return HttpNotFound();
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,SpeedingTickets,DUI,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                var existing = db.Insurees.Find(insuree.Id);
                if (existing != null)
                {
                    existing.FirstName = insuree.FirstName;
                    existing.LastName = insuree.LastName;
                    existing.EmailAddress = insuree.EmailAddress;
                    existing.DateOfBirth = insuree.DateOfBirth;
                    existing.CarYear = insuree.CarYear;
                    existing.CarMake = insuree.CarMake;
                    existing.CarModel = insuree.CarModel;
                    existing.SpeedingTickets = insuree.SpeedingTickets;
                    existing.DUI = insuree.DUI;
                    existing.CoverageType = insuree.CoverageType;
                    existing.Quote = insuree.Quote;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null) return HttpNotFound();
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Admin - list of all quotes with user details
        public ActionResult Admin()
        {
            return View(db.Insurees.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
