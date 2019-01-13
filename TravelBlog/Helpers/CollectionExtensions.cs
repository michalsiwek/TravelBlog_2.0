using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Models;

namespace TravelBlog.Helpers
{
    public static class CollectionExtensions
    {
        public static T GetRandomElement<T>(this IEnumerable<T> collection)
        {
            var count = collection.Count();
            var index = new Random().Next(0, count);
            return collection.ElementAt(index);
        }
    }
}