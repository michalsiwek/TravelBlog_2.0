using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.Viewmodels
{
    public class GalleryViewModel
    {
        public Gallery Gallery { get; set; }
        public IEnumerable<ContentSubcategory> ContentSubcategories { get; set; }
    }
}