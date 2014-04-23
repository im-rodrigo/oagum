using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oagum0._01.Models
{
    public class SearchViewModel
    {
        public int TotalArticleCount { get; set; }
        public int AllPages { get; set; }
        public string SearchString { get; set; }
    }
}