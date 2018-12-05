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

        public EntriesController()
        {
            _requestDataRepository = new RequestDataRepository();
            _paginationHandler = new PaginationHandler();
        }

        public ActionResult Index(int page)
        {
            var entriesPerPage = 3;

            var entries = _requestDataRepository.GetEntriesByCreateDateDesc();

            if (entries == null)
                return RedirectToAction("NoContent", "Home");

            var numbOfPages = (int)Math.Ceiling((double)entries.Count / entriesPerPage);

            if (page > numbOfPages)
                return RedirectToAction("Index", "Entries", new { page = numbOfPages });

            var viewModel = new EntriesViewModel
            {
                Pages = _paginationHandler.GetPages(page, numbOfPages),
                ActivePage = page,
                Entries = entries
                    .Skip((page - 1) * entriesPerPage)
                    .Take(entriesPerPage)
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

        public ActionResult Filter(string categoryName)
        {
            var output = _requestDataRepository.GetEntriesByCreateDateDesc().Skip(1).Take(10);

            var viewModel = new EntriesViewModel
            {
                Entries = _requestDataRepository.GetEntriesByCategoryAndCreateDateDesc(categoryName)
            };

            if (viewModel.Entries.Count() == 0)
                return RedirectToAction("NoContent", "Home");

            return View(viewModel);
        }
    }
}