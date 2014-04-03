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
    public class AuthorSmallMetadataController : Controller
    {
        private AuthorSmallMetadataContext db = new AuthorSmallMetadataContext();

        // GET: /AuthorSmallMetadata/
        public ActionResult Index()
        {
            return View(db.T_AuthorSmallMeDa.ToList());
        }

        // GET: /AuthorSmallMetadata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_AuthorSmallMeDa t_authorsmallmeda = db.T_AuthorSmallMeDa.Find(id);
            if (t_authorsmallmeda == null)
            {
                return HttpNotFound();
            }
            return View(t_authorsmallmeda);
        }

        //// GET: /AuthorSmallMetadata/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: /AuthorSmallMetadata/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Title,PubDate,Author,Link,ID")] T_AuthorSmallMeDa t_authorsmallmeda)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.T_AuthorSmallMeDa.Add(t_authorsmallmeda);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(t_authorsmallmeda);
        //}

        //// GET: /AuthorSmallMetadata/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    T_AuthorSmallMeDa t_authorsmallmeda = db.T_AuthorSmallMeDa.Find(id);
        //    if (t_authorsmallmeda == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(t_authorsmallmeda);
        //}

        //// POST: /AuthorSmallMetadata/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="Title,PubDate,Author,Link,ID")] T_AuthorSmallMeDa t_authorsmallmeda)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(t_authorsmallmeda).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(t_authorsmallmeda);
        //}

        //// GET: /AuthorSmallMetadata/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    T_AuthorSmallMeDa t_authorsmallmeda = db.T_AuthorSmallMeDa.Find(id);
        //    if (t_authorsmallmeda == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(t_authorsmallmeda);
        //}

        //// POST: /AuthorSmallMetadata/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    T_AuthorSmallMeDa t_authorsmallmeda = db.T_AuthorSmallMeDa.Find(id);
        //    db.T_AuthorSmallMeDa.Remove(t_authorsmallmeda);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
