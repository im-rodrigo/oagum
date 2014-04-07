using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using oagum0._01;
using System.Data.SqlClient;
using System.Text;

namespace oagum0._01.Controllers
{
    public class Article_ArtAutRelController : Controller
    {
        private ArticleAuthorRelationshipEntities db = new ArticleAuthorRelationshipEntities();

        // GET: /Article_ArtAutRel/
        public ActionResult Index()
        {
            return View(db.T_Article.ToList());
        }

        // GET: /Article_ArtAutRel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Article t_article = db.T_Article.Find(id);
            if (t_article == null)
            {
                return HttpNotFound();
            }
           
            //var authors = 
            //    from author in db.T_Author
            //    join articleauthor in db.T_ArticleAuthor 
            //    on author.ID equals articleauthor.AuthorId
            //    select author 
            //    wh

            SqlConnection sqlConnection1 = new SqlConnection(db.Database.Connection.ConnectionString.ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select x.Name from T_Author x join T_ArticleAuthor y on y.AuthorId = x.ID  where y.ArticleId = " + t_article.ID.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            StringBuilder authorstring = new StringBuilder(); 
            while (reader.Read())
            {
                  ViewBag.Authors += reader.GetValue(0);
                  ViewBag.Authors += "\r\n"; 
            }
            sqlConnection1.Close();

            return View(t_article);
        }

        // GET: /Article_ArtAutRel/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: /Article_ArtAutRel/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="ID,Title,PublishDate,Description,Source,InsertDate,CreatedBy")] T_Article t_article)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.T_Article.Add(t_article);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(t_article);
        //}

        //// GET: /Article_ArtAutRel/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    T_Article t_article = db.T_Article.Find(id);
        //    if (t_article == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(t_article);
        //}

        //// POST: /Article_ArtAutRel/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="ID,Title,PublishDate,Description,Source,InsertDate,CreatedBy")] T_Article t_article)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(t_article).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(t_article);
        //}

        //// GET: /Article_ArtAutRel/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    T_Article t_article = db.T_Article.Find(id);
        //    if (t_article == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(t_article);
        //}

        //// POST: /Article_ArtAutRel/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    T_Article t_article = db.T_Article.Find(id);
        //    db.T_Article.Remove(t_article);
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
