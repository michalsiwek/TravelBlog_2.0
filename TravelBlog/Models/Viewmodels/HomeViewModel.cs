using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.Viewmodels
{
    public class HomeViewModel
    {
        public IEnumerable<Entry> LastEntries { get; set; }
        public IEnumerable<Entry> OtherEntries { get; set; }
        public Entry RandomEntry { get; set; }
    }
}