using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TravelBlog.Infrastructure;
using TravelBlog.Models;
using TravelBlog.Models.Viewmodels;
using TravelBlog.Repository;

namespace TravelBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestDataRepository _requestDataRepository;

        public HomeController()
        {
            _requestDataRepository = new RequestDataRepository();
        }

        public ActionResult Index(int? page)
        {
            var entries = _requestDataRepository.GetEntriesByCreateDateDesc();

            if (entries == null)
                return RedirectToAction("NoContent", "Home");

            var viewModel = new HomeViewModel
            {
                LastEntries = _requestDataRepository.GetTop3EntriesByCreateDate(),
                OtherEntries = _requestDataRepository.GetEntriesByCreateDateDesc().Skip(3).Take(5),
                RandomEntry = _requestDataRepository.GetRandomEntry()
            };

            return View(viewModel);
        }

        public ActionResult AboutMe()
        {
            var viewModel = new AboutMeViewModel
            {
                RandomEntry = _requestDataRepository.GetRandomEntry()
            };

            return View(viewModel);
        }

        public ActionResult NoContent()
        {
            return View();
        }

    }
}