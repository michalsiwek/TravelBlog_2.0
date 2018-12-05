using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Models;
using TravelBlog.Models.Viewmodels;
using TravelBlog.Repository;

namespace TravelBlog.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IRequestDataRepository _requestDataRepository;

        public EntriesController() => _requestDataRepository = new RequestDataRepository();

        public ActionResult Index(int page)
        {
            var entriesPerPage = 3;

            var entries = _requestDataRepository.GetEntriesByCreateDateDesc();
            var pages = (int)Math.Ceiling((double)entries.Count / entriesPerPage);

            if (page > pages)
                return RedirectToAction("Index", RedirectToAction("Index", "Entries", new {page = pages}));

            var viewModel = new EntriesViewModel
            {
                Pages = pages,
                Page = page,
                Entries = _requestDataRepository.GetEntriesByCreateDateDesc()
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