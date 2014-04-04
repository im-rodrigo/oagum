using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using oagum0._01.Models;

namespace oagum0._01.Controllers
{
    public class PublisherSmallMetadataController : Controller
    {
        private PublisherSmallMetadataContext db = new PublisherSmallMetadataContext();

        // GET: /PublisherSmallMetadata/
        public ActionResult Index()
        {
            return View(db.T_PublisherSmallMeDa.ToList());
        }

        // GET: /PublisherSmallMetadata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PublisherSmallMeDa t_publishersmallmeda = db.T_PublisherSmallMeDa.Find(id);
            if (t_publishersmallmeda == null)
            {
                return HttpNotFound();
            }
            return View(t_publishersmallmeda);
        }

        // GET: /PublisherSmallMetadata/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PublisherSmallMetadata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Title,PubDate,Publisher,Link,ID")] T_PublisherSmallMeDa t_publishersmallmeda)
        {
            if (ModelState.IsValid)
            {
                db.T_PublisherSmallMeDa.Add(t_publishersmallmeda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_publishersmallmeda);
        }

        // GET: /PublisherSmallMetadata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PublisherSmallMeDa t_publishersmallmeda = db.T_PublisherSmallMeDa.Find(id);
            if (t_publishersmallmeda == null)
            {
                return HttpNotFound();
            }
            return View(t_publishersmallmeda);
        }

        // POST: /PublisherSmallMetadata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Title,PubDate,Publisher,Link,ID")] T_PublisherSmallMeDa t_publishersmallmeda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_publishersmallmeda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_publishersmallmeda);
        }

        // GET: /PublisherSmallMetadata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PublisherSmallMeDa t_publishersmallmeda = db.T_PublisherSmallMeDa.Find(id);
            if (t_publishersmallmeda == null)
            {
                return HttpNotFound();
            }
            return View(t_publishersmallmeda);
        }

        // POST: /PublisherSmallMetadata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_PublisherSmallMeDa t_publishersmallmeda = db.T_PublisherSmallMeDa.Find(id);
            db.T_PublisherSmallMeDa.Remove(t_publishersmallmeda);
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
