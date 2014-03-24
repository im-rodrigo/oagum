using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/* I just wanted to add that you can't be disappointed in EF about this. 
 * It is a limitation brought about by the inherent differences between
 * a relational data model and an object oriented data model. 
 * Different concepts.
 */
namespace oagum0._01.Models
{
    /*The class' member variable definitions follow the OAI-PMH standard
     * These members will be referred to via url search query 
     * ex. search?source={"query":{"filtered":{"query":{"match_all":{}},"filter":{"bool":{"must":[{"term":{"id":"c8975f927ee643b994d187e174e56415"}}]}}}}}
     * keys: [-publisher,-description,-language,?format,-type,-rights,-date,-relation,?source,coverage,contributor,title,identifier,creator,subject]
     */

    public class Article
    {
        public int ID { get; set; }
        public string publisher { get; set; }//this is composed of the bottom three identifiers..
        public string description { get; set; }
        public string language { get; set; }
        public string format { get; set; }
        public string type { get; set; }
        public string rights { get; set; }
        public string date { get; set; }
        public string relation { get; set; }
        public string source { get; set; }
        public string coverage { get; set; }
        public string contributor { get; set; }
        public string title { get; set; }
        public string identifier { get; set; }
        public string creator { get; set; }
        public string subject { get; set; }
        /*
        public int ID { get; set; }
        public string Identifier { get; set; }//this is composed of the bottom three identifiers..
        public string Title { get; set; }
        public string Creators { get; set; }
        public DateTime Date { get; set; }
        public string Subjects { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string Rights { get; set; }
        public string Type{ get; set; }
        //public string Format { get; set; }
        public string Relation { get; set; }//when harvesting data from doaj.org/oai... the contents of node 'relation' contains the article's link 
        */
        /*
        public string DOI { get; set; }//digital objec identifier
        public string pISSN { get; set; }//printed international standard serial number
        public string eISSN { get; set; }//electronic international standard serial number
        */
    }
}