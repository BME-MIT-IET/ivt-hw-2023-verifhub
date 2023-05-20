using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearchApp.Models
{
    //Response Format from Api
    //Not all needed
    public class Author
    {
        public string wikipedia { get; set; }
        public string personal_name { get; set; }
        public string key { get; set; }
        public string[] alternate_names { get; set; }
        public Remote_Ids remote_ids { get; set; }
        public Type type { get; set; }
        public Link[] links { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string birth_date { get; set; }
        public string entity_type { get; set; }
        public int[] photos { get; set; }
        public string[] source_records { get; set; }
        public string bio { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public Created created { get; set; }
        public Last_Modified last_modified { get; set; }
    }

    public class Remote_Ids
    {
        public string wikidata { get; set; }
        public string isni { get; set; }
        public string goodreads { get; set; }
        public string viaf { get; set; }
        public string librarything { get; set; }
        public string amazon { get; set; }
    }

    public class Type
    {
        public string key { get; set; }
    }

    public class Created
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Last_Modified
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Link
    {
        public string title { get; set; }
        public string url { get; set; }
        public Type1 type { get; set; }
    }

    public class Type1
    {
        public string key { get; set; }
    }
}
