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
    public class GalleriesController : Controller
    {
        private readonly IRequestDataRepository _requestDataRepository;
        private readonly IGalleriesService _galleriesService;

        public GalleriesController()
        {
            _requestDataRepository = new RequestDataRepository();
            _galleriesService = new GalleriesService();
        }

        public ActionResult Index()
        {
            var viewModel = new GalleriesViewModel
            {
                Galleries = _requestDataRepository.GetElements<Gallery>()
            };

            if (viewModel.Galleries.Count == 0)
                RedirectToAction("Index", "Home");

            foreach (var gallery in viewModel.Galleries)
                _galleriesService.GeneratePictureUrls(gallery);

            return View(viewModel);
        }

        public ActionResult Gallery(int id)
        {
            var viewModel = new GalleryViewModel()
            {
                Gallery = _requestDataRepository.GetElement<Gallery>(id)
            };

            _galleriesService.GeneratePictureUrls(viewModel.Gallery);

            return View(viewModel);
        }
    }
}