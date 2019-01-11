using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.Viewmodels
{
    public class EntryViewModel
    {
        public Entry Entry { get; set; }
        public IEnumerable<ContentSubcategory> ContentSubcategories { get; set; }
    }
}