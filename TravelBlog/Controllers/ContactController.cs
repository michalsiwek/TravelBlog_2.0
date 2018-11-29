using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Infrastructure;
using TravelBlog.Models.Viewmodels;

namespace TravelBlog.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISendEmailService _emailService;

        public ContactController() => _emailService = new SendEmailService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmail(ContactViewModel model)
        {
            _emailService.SendEmail(model);

            return RedirectToAction("Index", "Home");
        }
    }
}