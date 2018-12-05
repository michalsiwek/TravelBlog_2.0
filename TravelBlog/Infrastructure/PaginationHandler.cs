using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Models.Viewmodels;

namespace TravelBlog.Infrastructure
{
    public interface IPaginationHandler
    {
        List<Page> GetPages(int pageRequest, int numbOfPages);
    }

    public class PaginationHandler : IPaginationHandler
    {
        public List<Page> GetPages(int pageRequest, int numbOfPages)
        {
            var pages = new List<Page>();

            if (pageRequest <= 2)
            {
                for (int i = 1; i <= Math.Min(numbOfPages, 5); i++)
                {
                    var temp = new Page
                    {
                        Index = i
                    };

                    if (i == pageRequest)
                        temp.Active = true;

                    pages.Add(temp);
                }
                return pages;
            }
            else if (numbOfPages > 5 && pageRequest > 2 && pageRequest < numbOfPages - 1)
            {
                for (int i = pageRequest - 2; i <= pageRequest + 2; i++)
                {
                    pages.Add(new Page { Index = i });
                }
                pages[2].Active = true;
                return pages;
            }
            else
            {
                for (int i = numbOfPages - 4; i <= numbOfPages; i++)
                {
                    var temp = new Page
                    {
                        Index = i
                    };

                    if (i == pageRequest)
                        temp.Active = true;

                    pages.Add(temp);
                }
                return pages;
            }
        }
    }
}