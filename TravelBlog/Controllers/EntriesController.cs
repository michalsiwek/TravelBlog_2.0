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

            return View(viewModel);
        }

        public ActionResult Filter(string categoryName)
        {
            var viewModel = new EntriesViewModel
            {
                Entries = _requestDataRepository.GetEntriesByCategoryAndCreateDateDesc(categoryName)
            };

            return View(viewModel);
        }
    }
}