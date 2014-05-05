using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using PagedList;
using oagum0._01.Models;
using Apitron.PDF;

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
            //here 'articles' now has the entire set of articles containing the search string in the Title
            ViewBag.SearchCount = articles.Count();


            int elemPerPage = 20;
            int numOfPage = (pageNo ?? 1);
            var res = articles.OrderBy(p => p.Title).ToPagedList(numOfPage, elemPerPage);

            var i = res.ElementAt(0);
            string sourceurl = i.Source;

            var pdfrequest = Request;

           // var strm = new System.IO.StreamReader();

           // Apitron.PDF.Rasterizer.Document pdfDoc = new Apitron.PDF.Rasterizer.Document(Request.GetBufferedInputStream();


            //here 'res' now has subsets of 'articles' limited to 20 per page (elemPerPage)
            return View(res);

            //return View(articles.OrderBy(p => p.Title).Skip((searchClient.CurrentPage - 1)*20).Take(searchClient.CurrentPage*20));
        }


        [HttpGet]
        public ActionResult UserFavorites()
        {
            List<int> favorites = null;

            int ID = Convert.ToInt32(Session["userId"]);
            using (Models.MembershipEntities1 memberDatabase = new MembershipEntities1())
            {
                favorites = memberDatabase.UserArticles.Where(User => User.UserId == ID).Select(Article => Article.ArticleId).ToList();

            }
            var articles = db.T_Article.Where(Article => favorites.Contains(Article.ID)).ToList();
            //var articles = from article in db.T_Article
            //               select article;


            return View(articles);

           
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