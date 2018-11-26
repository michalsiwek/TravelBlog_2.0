using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Models;

namespace TravelBlog.Infrastructure
{
    public interface IGalleriesService
    {
        void GeneratePictureUrls(Gallery gallery);
    }
    public class GalleriesService : IGalleriesService
    {
        public void GeneratePictureUrls(Gallery gallery)
        {
            foreach (var picture in gallery.Pictures)
            {
                var temp = picture.Url;
                picture.Url = ConnectionFactory.GetServerAddress() + temp;
            }
        }
    }
}