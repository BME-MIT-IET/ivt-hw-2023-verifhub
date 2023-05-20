using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearchApp.Models
{
    //Response Format from Api
    //Not all needed
    public class BooksResponse
    {
        public int NumFound { get; set; }
        public int Start { get; set; }
        public List<Book> Docs { get; set; }
    }
    public class Book
    {
        public int cover_i { get; set; }
        public bool has_fulltext { get; set; }
        public int edition_count { get; set; }
        public string title { get; set; }
        public string[] author_name { get; set; }
        public int first_publish_year { get; set; }
        public string key { get; set; }
        public string[] ia { get; set; }
        public string[] author_key { get; set; }
        public bool public_scan_b { get; set; }
        public string FirstAuthorName//get the first author's name and we only show this
        {
            get
            {
                if (author_name != null && author_name.Length > 0)
                {
                    return author_name[0];
                }
                return null;
            }
        }
        public string FirstAuthorKey//get the first author's key and we only show this author's detail
        {
            get 
            {
                if (author_key != null && author_key.Length > 0)
                {
                    return author_key[0];
                }
                return null;
            }
        }
        public string ImageUrl { get; set; }
        public string []language { get; set; }
    }
}
