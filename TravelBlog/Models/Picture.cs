﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models
{
    public class Picture
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string Descripton { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public DateTime UploadDate { get; set; }

        public int GalleryId { get; set; }
    }
}