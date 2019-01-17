using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Infrastructure;
using TravelBlog.Models.Viewmodels;
using TravelBlog.Repository;

namespace TravelBlog.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISendEmailService _emailService;
        private readonly IRequestDataRepository _requestDataRepository;

        public ContactController()
        {
            _emailService = new SendEmailService();
            _requestDataRepository = new RequestDataRepository();
        }

        public ActionResult Index()
        {
            var viewmodel = new ContactViewModel
            {
                RandomEntry = _requestDataRepository.GetRandomEntry()
            };

            return View(viewmodel);
        }

        public ActionResult SendEmail(ContactViewModel model)
        {
            _emailService.SendEmail(model);

            return RedirectToAction("Index", "Home");
        }
    }
}