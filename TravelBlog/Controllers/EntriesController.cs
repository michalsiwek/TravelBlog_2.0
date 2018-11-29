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

        public ActionResult Index()
        {
            var viewModel = new EntriesViewModel
            {
                Entries = _requestDataRepository.GetEntriesByCreateDateDesc()
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