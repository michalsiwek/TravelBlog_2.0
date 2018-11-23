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
using TravelBlog.Models;
using TravelBlog.Models.Viewmodels;
using TravelBlog.Repository;

namespace TravelBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestDataRepository _requestDataRepository;

        public HomeController() => _requestDataRepository = new RequestDataRepository();

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