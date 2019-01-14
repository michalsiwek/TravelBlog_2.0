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
            viewModel.RandomEntry = _requestDataRepository.GetRandomEntry();

            if (viewModel.Entries.Count() == 0)
                return RedirectToAction("NoContent", "Home");

            return View(viewModel);
        }

        public ActionResult Entry(int id)
        {
            var entry = _requestDataRepository.GetElement<Entry>(id);
            var contentSubcategories = _requestDataRepository.GetContentSubcategoriesByParentId(entry.CategoryId);

            var viewModel = new EntryViewModel
            {
                Entry = entry,
                ContentSubcategories = contentSubcategories,
                RandomEntry = _requestDataRepository.GetRandomEntry()
            };

            if (viewModel.Entry == null)
                return RedirectToAction("NoContent", "Home");

            return View(viewModel);
        }

        public ActionResult Category(int id, int? page)
        {
            var entries = _requestDataRepository.GetEntriesByCategoryAndCreateDateDesc(id);

            if (entries == null)
                return RedirectToAction("NoContent", "Home");

            var contentSubCategories = _requestDataRepository.GetContentSubcategoriesByParentId(id);           

            var viewModel = _viewModelProvider.GetViewModel(page, entries, null, contentSubCategories);
            viewModel.RandomEntry = _requestDataRepository.GetRandomEntry();

            if (viewModel.Entries.Count() == 0)
                return RedirectToAction("NoContent", "Home");

            return View(viewModel);
        }

        public ActionResult Subcategory(int id, int? page)
        {
            var entries = _requestDataRepository.GetEntriesBySubcategoryAndCreateDateDesc(id);

            if (entries == null)
                return RedirectToAction("NoContent", "Home");

            var contentSubCategories = _requestDataRepository.GetContentSubcategoriesByParentId(entries.First().CategoryId);            

            var viewModel = _viewModelProvider.GetViewModel(page, entries, null, contentSubCategories);
            viewModel.RandomEntry = _requestDataRepository.GetRandomEntry();

            if (viewModel.Entries.Count() == 0)
                return RedirectToAction("NoContent", "Home");

            return View(viewModel);
        }
    }
}