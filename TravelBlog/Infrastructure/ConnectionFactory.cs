using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Infrastructure
{
    public static class ConnectionFactory
    {
        public static string GetServerAddress()
        {
            return @"http://blogmanager.azurewebsites.net";
        }
    }
}