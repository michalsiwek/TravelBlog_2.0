using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Helpers;

namespace TravelBlog.Models
{
    public class Entry
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastModification { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Content { get; set; }
        public string ImageUrl { get; set; }


        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }

        public string Author { get; set; }
        public string LastEditor { get; set; }

        public string GetCategoryForUrl()
        {
            return CategoryName.ToLower().UnPolish().Replace(" ", "-");
        }
    }
}