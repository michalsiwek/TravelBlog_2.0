using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Models;
using TravelBlog.Models.Viewmodels;

namespace TravelBlog.Infrastructure
{
    public interface IEntriesViewModelProvider
    {
        EntriesViewModel GetViewModel(int? pageRequest, IEnumerable<Entry> entries);
    }

    public class EntriesViewModelProvider : IEntriesViewModelProvider
    {
        private readonly IPaginationHandler _paginationHandler;
        private readonly int _entriesPerPage = 3;

        public EntriesViewModelProvider(IPaginationHandler paginationHandler)
        {
            _paginationHandler = paginationHandler;
        }

        public EntriesViewModel GetViewModel(int? pageRequest, IEnumerable<Entry> entries)
        {
            int page = (pageRequest == null || pageRequest < 1) ? 1 : (int)pageRequest;

            var numbOfPages = _paginationHandler.CalculatePages(entries.Count(), _entriesPerPage);

            if (page > numbOfPages)
                page = numbOfPages;

            var viewModel = new EntriesViewModel
            {
                Pages = _paginationHandler.GetPages(page, numbOfPages),
                ActivePage = page,
                Entries = entries
                    .Skip((page - 1) * _entriesPerPage)
                    .Take(_entriesPerPage),
                AllPagesCount = numbOfPages
            };

            return viewModel;
        }
    }
}