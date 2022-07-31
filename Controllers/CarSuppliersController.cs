using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationBlog.Models;

namespace WebApplicationBlog.Controllers
{
    public class CarSuppliersController : Controller
    {
        private MainContext db = new MainContext();

        // GET: CarSuppliers
        public ActionResult Index()
        {
            return View(db.CarSuppliers.ToList());
        }

        // GET: CarSuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSupplier carSupplier = db.CarSuppliers.Find(id);
            if (carSupplier == null)
            {
                return HttpNotFound();
            }
            return View(carSupplier);
        }

        // GET: CarSuppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SupplierName")] CarSupplier carSupplier)
        {
            if (ModelState.IsValid)
            {
                db.CarSuppliers.Add(carSupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carSupplier);
        }

        // GET: CarSuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSupplier carSupplier = db.CarSuppliers.Find(id);
            if (carSupplier == null)
            {
                return HttpNotFound();
            }
            return View(carSupplier);
        }

        // POST: CarSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SupplierName")] CarSupplier carSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carSupplier);
        }

        // GET: CarSuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSupplier carSupplier = db.CarSuppliers.Find(id);
            if (carSupplier == null)
            {
                return HttpNotFound();
            }
            return View(carSupplier);
        }

        // POST: CarSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarSupplier carSupplier = db.CarSuppliers.Find(id);
            db.CarSuppliers.Remove(carSupplier);
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
