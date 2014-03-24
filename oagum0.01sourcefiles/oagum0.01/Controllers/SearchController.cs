using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using oagum0._01.JsonMigration;
using oagum0._01.Models;

namespace oagum0._01.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        public ActionResult Index()
        {
            JsonMigration.JsonMigrator migrator = new JsonMigrator(); 
            migrator.Migrate();
            Article testArticle = migrator.getDeserializedArticle();
            return View();
        }
        public string Welcome(string name, int numTimes = 1)
        {
            return HttpUtility.HtmlEncode("Hello" + name + ",Numtimes is: " + numTimes);
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