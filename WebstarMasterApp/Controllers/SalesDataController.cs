using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebstarMasterApp.Models;

namespace WebstarMasterApp.Controllers
{
    public class SalesDataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: SalesData
        public ActionResult Index()
        {
            return View(db.SalesData.ToList());
        }

        [Authorize]
        // GET: SalesData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesData salesData = db.SalesData.Find(id);
            if (salesData == null)
            {
                return HttpNotFound();
            }
            return View(salesData);
        }

        [Authorize(Roles = "Admin")]
        // GET: SalesData/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: SalesData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,KitchenAndBath,HomeAndGarden,Electronics,BooksAndMedia")] SalesData salesData)
        {
            if (ModelState.IsValid)
            {
                db.SalesData.Add(salesData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesData);
        }

        [Authorize(Roles = "Admin")]
        // GET: SalesData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesData salesData = db.SalesData.Find(id);
            if (salesData == null)
            {
                return HttpNotFound();
            }
            return View(salesData);
        }

        [Authorize(Roles = "Admin")]
        // POST: SalesData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,KitchenAndBath,HomeAndGarden,Electronics,BooksAndMedia")] SalesData salesData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesData);
        }

        [Authorize(Roles = "Admin")]
        // GET: SalesData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesData salesData = db.SalesData.Find(id);
            if (salesData == null)
            {
                return HttpNotFound();
            }
            return View(salesData);
        }

        [Authorize(Roles = "Admin")]
        // POST: SalesData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesData salesData = db.SalesData.Find(id);
            db.SalesData.Remove(salesData);
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
