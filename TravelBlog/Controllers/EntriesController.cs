using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                Entries = _requestDataRepository.GetTop3EntriesByCreateDate()
            };

            return View(viewModel);
        }
    }
}