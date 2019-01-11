using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.Viewmodels
{
    public class GalleriesViewModel
    {
        public List<Gallery> Galleries { get; set; }
        public IEnumerable<ContentCategory> ContentCategories { get; set; }
        public IEnumerable<ContentSubcategory> ContentSubcategories { get; set; }
    }
}