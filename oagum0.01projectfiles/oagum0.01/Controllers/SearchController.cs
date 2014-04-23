using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using PagedList;
using oagum0._01.Models;

namespace oagum0._01.Controllers
{
    public class SearchController : Controller
    {
        private ArticleAuthorRelationshipEntities db = new ArticleAuthorRelationshipEntities();
        private SearchViewModel searchClient = new SearchViewModel();
        // GET: /Search/
        public ActionResult Index()
        {
            var articles = db.T_Article.ToList();
            
            ViewBag.TotalCount = articles.Count();
            return View();
        }

        // GET: /Search/Results?searchString=radiation
        [HttpGet]
        public ActionResult Results(string searchString, string filterString, int? pageNo)
        {
            //searchClient.CurrentPage = pageNo;

            var articles = from article in db.T_Article
                           select article;

            ViewBag.TotalCount = articles.Count();

            if (searchString != null)
            {
                pageNo = 1;
                //ViewBag.SearchString = searchString;
            }
            else
            {
                searchString = filterString;
            }

            ViewBag.FilterString = searchString;
            //var querysubstring = searchString.Split('&');

            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Title.Contains(searchString));
            }

            ViewBag.SearchCount = articles.Count();

            int elemPerPage = 1;
            int numOfPage = (pageNo ?? 1);
            var res = articles.OrderBy(p => p.Title).ToPagedList(numOfPage, elemPerPage);
            return View(res);

            //return View(articles.OrderBy(p => p.Title).Skip((searchClient.CurrentPage - 1)*20).Take(searchClient.CurrentPage*20));
        }

        // GET: /Search/Details/5
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

            var authors =
                (from author in db.T_Author
                 join authorarticle in db.T_ArticleAuthor
                 on author.ID equals authorarticle.AuthorId
                 where (authorarticle.ArticleId == id)
                 select new
                 {
                     author.Name
                 });
          
            ViewBag.Authors = authors;
            return View(t_article);
        }

	}
}