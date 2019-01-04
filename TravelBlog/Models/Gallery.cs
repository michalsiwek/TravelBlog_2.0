using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models
{
    public class Gallery
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<Picture> Pictures { get; set; }

        public string CreatedBy { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastModification { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }

    }
}