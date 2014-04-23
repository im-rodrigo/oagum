using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using oagum0._01.extrafiles;

namespace oagum0._01.Controllers
{
    public class PublisherController : Controller
    {
        private PublisherMetadataEntity db = new PublisherMetadataEntity();

        // GET: /Publisher/
        public ActionResult Index()
        {
            return View(db.T_Publisher.ToList());
        }

        // GET: /Publisher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Publisher t_publisher = db.T_Publisher.Find(id);
            if (t_publisher == null)
            {
                return HttpNotFound();
            }
            return View(t_publisher);
        }

        // GET: /Publisher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Publisher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,InsertDate,CreatedUser")] T_Publisher t_publisher)
        {
            if (ModelState.IsValid)
            {
                db.T_Publisher.Add(t_publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_publisher);
        }

        // GET: /Publisher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Publisher t_publisher = db.T_Publisher.Find(id);
            if (t_publisher == null)
            {
                return HttpNotFound();
            }
            return View(t_publisher);
        }

        // POST: /Publisher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,InsertDate,CreatedUser")] T_Publisher t_publisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_publisher);
        }

        // GET: /Publisher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Publisher t_publisher = db.T_Publisher.Find(id);
            if (t_publisher == null)
            {
                return HttpNotFound();
            }
            return View(t_publisher);
        }

        // POST: /Publisher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Publisher t_publisher = db.T_Publisher.Find(id);
            db.T_Publisher.Remove(t_publisher);
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
