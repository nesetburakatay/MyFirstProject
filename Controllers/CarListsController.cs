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
    public class CarListsController : Controller
    {
        private MainContext db = new MainContext();

        // GET: CarLists
        public ActionResult Index()
        {
            var carLists = db.CarLists.Include(c => c.CarCategory);
            return View(carLists.ToList());
        }

        // GET: CarLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarList carList = db.CarLists.Find(id);
            if (carList == null)
            {
                return HttpNotFound();
            }
            return View(carList);
        }

        // GET: CarLists/Create
        public ActionResult Create()
        {
            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "Id", "CategoryName");
            return View();
        }

        // POST: CarLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarBrand,CarUnicId,ModelYear,CarColor,CarPicture,CarState,CarCategoryId")] CarList carList)
        {
            if (ModelState.IsValid)
            {
                db.CarLists.Add(carList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "Id", "CategoryName", carList.CarCategoryId);
            return View(carList);
        }

        // GET: CarLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarList carList = db.CarLists.Find(id);
            if (carList == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "Id", "CategoryName", carList.CarCategoryId);
            return View(carList);
        }

        // POST: CarLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarBrand,CarUnicId,ModelYear,CarColor,CarPicture,CarState,CarCategoryId")] CarList carList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "Id", "CategoryName", carList.CarCategoryId);
            return View(carList);
        }

        // GET: CarLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarList carList = db.CarLists.Find(id);
            if (carList == null)
            {
                return HttpNotFound();
            }
            return View(carList);
        }

        // POST: CarLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarList carList = db.CarLists.Find(id);
            db.CarLists.Remove(carList);
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
