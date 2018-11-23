using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.Viewmodels
{
    public class GalleriesViewModel
    {
        public IEnumerable<Gallery> Galleries { get; set; }
    }
}