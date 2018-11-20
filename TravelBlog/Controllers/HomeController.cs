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
using TravelBlog.Repository;

namespace TravelBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly RequestDataRepository _requestDataRepository;

        public HomeController() => _requestDataRepository = new RequestDataRepository();

        public ActionResult Index()
        {
            var top3 = _requestDataRepository.GetTop3EntriesByCreateDate();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}