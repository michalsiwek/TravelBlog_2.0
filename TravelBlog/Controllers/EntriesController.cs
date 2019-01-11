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
        private readonly IEntriesViewModelProvider _viewModelProvider;

        public EntriesController()
        {
            _requestDataRepository = new RequestDataRepository();
            _viewModelProvider = new EntriesViewModelProvider(new PaginationHandler());
        }

        public ActionResult Index(int? page)
        {
            var entries = _requestDataRepository.GetEntriesByCreateDateDesc();
            var contentCategories = _requestDataRepository.GetElements<ContentCategory>();

            if (entries == null)
                return RedirectToAction("NoContent", "Home");

            var viewModel = _viewModelProvider.GetViewModel(page, entries, contentCategories);

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

        public ActionResult Filter(int catId, int? page)
        {
            var entries = _requestDataRepository.GetEntriesByCategoryAndCreateDateDesc(catId);
            var contentSubCategories = _requestDataRepository.GetContentSubcategoriesByParentId(catId);

            if (entries == null)
                return RedirectToAction("NoContent", "Home");

            var viewModel = _viewModelProvider.GetViewModel(page, entries, null, contentSubCategories);

            if (viewModel.Entries.Count() == 0)
                return RedirectToAction("NoContent", "Home");

            return View(viewModel);
        }
    }
}