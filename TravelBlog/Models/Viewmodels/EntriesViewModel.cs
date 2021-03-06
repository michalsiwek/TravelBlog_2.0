﻿using System;
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
        public IEnumerable<ContentCategory> ContentCategories { get; set; }
        public IEnumerable<ContentSubcategory> ContentSubcategories { get; set; }
        public Entry RandomEntry { get; set; }
        public int AllPagesCount { get; set; }
    }
}