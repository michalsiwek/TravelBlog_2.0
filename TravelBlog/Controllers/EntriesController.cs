using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Infrastructure;
using TravelBlog.Models;
using TravelBlog.Models.Viewmodels;
using TravelBlog.Repository;

namespace TravelBlog.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IRequestDataRepository _requestDataRepository;
        private readonly IPaginationHandler _paginationHandler;
        private readonly int _entriesPerPage = 3;

        public EntriesController()
        {
            _requestDataRepository = new RequestDataRepository();
            _paginationHandler = new PaginationHandler();
        }

        public ActionResult Index(int? page)
        {
            var entries = _requestDataRepository.GetEntriesByCreateDateDesc();

            if (entries == null)
                return RedirectToAction("NoContent", "Home");

            int pageRequest = (page == null || page < 1) ? 1 : (int)page;

            var numbOfPages = (int)Math.Ceiling((double)entries.Count / _entriesPerPage);

            if (pageRequest > numbOfPages)
                return RedirectToAction("Index", "Entries", new { page = numbOfPages });

            var viewModel = new EntriesViewModel
            {
                Pages = _paginationHandler.GetPages(pageRequest, numbOfPages),
                ActivePage = pageRequest,
                Entries = entries
                    .Skip((pageRequest - 1) * _entriesPerPage)
                    .Take(_entriesPerPage),
                AllPagesCount = numbOfPages
            };

            if (viewModel.Entries.Count() == 0)
                return RedirectToAction("NoContent", "Home");

            return View(viewModel);
        }

        public ActionResult Entry(int id)
        {
            var viewModel = new EntryViewModel
            {
                Entry = _requestDataRepository.GetElement<Entry>(id)
            };

            if (viewModel.Entry == null)
                return RedirectToAction("NoContent", "Home");

            return View(viewModel);
        }

        public ActionResult Filter(string categoryName, int? page)
        {
            var entries = _requestDataRepository.GetEntriesByCategoryAndCreateDateDesc(categoryName);

            if (entries == null)
                return RedirectToAction("NoContent", "Home");

            int pageRequest = (page == null || page < 1) ? 1 : (int)page;

            var numbOfPages = (int)Math.Ceiling((double)entries.Count / _entriesPerPage);

            if (page > numbOfPages)
                return RedirectToAction("Filter", "Entries", new { categoryName = categoryName, page = numbOfPages });

            var viewModel = new EntriesViewModel
            {
                Pages = _paginationHandler.GetPages(pageRequest, numbOfPages),
                ActivePage = pageRequest,
                Entries = entries
                    .Skip((pageRequest - 1) * _entriesPerPage)
                    .Take(_entriesPerPage),
                AllPagesCount = numbOfPages
            };

            if (viewModel.Entries.Count() == 0)
                return RedirectToAction("NoContent", "Home");

            return View(viewModel);
        }
    }
}