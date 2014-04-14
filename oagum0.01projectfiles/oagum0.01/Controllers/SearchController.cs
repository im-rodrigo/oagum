using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oagum0._01.Models;

namespace oagum0._01.Controllers
{
    public class SearchController : Controller
    {
        private ArticleAuthorRelationshipEntities db = new ArticleAuthorRelationshipEntities(); 

        // GET: /Search/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Results(string searchString)
        {
            var articles = from article in db.T_Article
                           select article;

            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Title.Contains(searchString));
            }

            return View(articles);
        }

        /*
        public string Index()
        {
            return "This is my <b>default</b> action... It returns a string!";
        }

        public string Welcome()
        {
            return "This is the Welcome action method. MVC 5 can translate your url .../search/welcome as an action.\n Instead of returning a 'View', which is a file containing html, this controller is returning a string."; 
        } */

	}
}