using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TravelBlog.Infrastructure
{
    public interface IRequestService
    {
        string GetTypeRoute(string type);
    }

    public class RequestService : IRequestService
    {
        public string GetTypeRoute(string type)
        {
            switch (type)
            {
                case "Entry":
                    return "Entries";
                case "Gallery":
                    return "Galleries";
                default:
                    return null;
            }
        }
    }
}