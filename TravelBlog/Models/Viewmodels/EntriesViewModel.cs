using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.Viewmodels
{
    public class EntriesViewModel
    {
        public int ActivePage { get; set; }
        public IEnumerable<Page> Pages { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
        public int AllPagesCount { get; set; }
    }
}