//http://blogs.msdn.com/b/dilkushp/archive/2013/10/31/easiest-way-of-loading-json-data-in-sql-using-c.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Data;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using oagum0._01.Models;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace oagum0._01.JsonMigration
{

    public class JsonMigrator
    {
        public Article article { get; set; }
        public string[] oaifilepath { get; set; }
        public JsonMigrator()
        { }
        public void Migrate()
        {
            List<string> errors = new List<string>();
            //Article newArticle = new Article(); 
            //String extrafilespath = "C:\\Users\\Rodrigo\\Documents\\Visual Studio 2013\\Projects\\oagum0.01\\oagum0.01\\extrafiles\\oaidata01.txt";
            oaifilepath = System.IO.File.ReadAllLines(@"C:\jsonfiles\oaidata01.txt");
            string json = new StreamReader(@"C:\jsonfiles\oaidata01.txt").ReadToEnd();
            string oailine = "";
            int i = 0;

            oailine = oailine.Insert(i, oaifilepath[i]);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(oailine);
            String newline = sb.ToString();
            newline = newline.Replace("\"", @"""");
            Dictionary<string, string> sData = new Dictionary<string,string>();
            var jss = new JavaScriptSerializer();
            try
            {
                 sData = jss.Deserialize<Dictionary<string, string>>(json);
            }
            catch (Exception e)
            {
                errors.Add(e.ToString());
               
            }
           

            string _Name = sData["Name"].ToString();
            string _Subject = sData["Subject"].ToString();
            string _Email = sData["Email"].ToString();
            string _Details = sData["Details"].ToString();

            JsonSerializer serializer = new JsonSerializer();


            article = JsontoArticle(newline);
            //XmlDocument xml = JsonConvert.DeserializeObject<Article>(oaifile);
        }

        private Article JsontoArticle(string str)
        {
            List<string> errors = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(str);



            Article deserializedArticle = new Article();
            try
            {
                deserializedArticle = JsonConvert.DeserializeObject<Article>(sb.ToString(), new JsonSerializerSettings
                {
                    Error = delegate(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                    {
                        Debug.WriteLine(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    }
                });
            }
            catch (Exception e)
            {
                errors.Add(e.ToString());

            }

            //article art = new article();
            //art = deserializedArticle.ElementAt(0);
            return deserializedArticle;
        }

        public Article getDeserializedArticle()
        {
            return article;
        }

    }
}