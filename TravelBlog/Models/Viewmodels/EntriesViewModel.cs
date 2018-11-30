using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.Viewmodels
{
    public class EntriesViewModel
    {
        public int Pages { get; set; }
        public int Page { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
    }
}