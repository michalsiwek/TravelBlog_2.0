using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Helpers
{
    public static class StringExtensions
    {
        public static string UnPolish(this string text)
        {
            return text.Replace("ą", "a")
                .Replace("ę", "e")
                .Replace("ć", "c")
                .Replace("ł", "l")
                .Replace("ó", "o")
                .Replace("ń", "n")
                .Replace("ś", "s")
                .Replace("ź", "z")
                .Replace("ż", "z");
        }
    }
}