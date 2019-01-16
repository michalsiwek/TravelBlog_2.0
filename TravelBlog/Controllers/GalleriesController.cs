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
                Galleries = _requestDataRepository.GetGalleriesByCreateDateDesc(),
                RandomEntry = _requestDataRepository.GetRandomEntry(),
                ContentCategories = _requestDataRepository.GetContentCategories_Gallery()
            };

            if (viewModel.Galleries.Count == 0)
                RedirectToAction("NoContent", "Home");

            foreach (var gallery in viewModel.Galleries)
                _galleriesService.GeneratePictureUrls(gallery);

            return View(viewModel);
        }

        public ActionResult Gallery(int id)
        {
            var gallery = _requestDataRepository.GetElement<Gallery>(id);

            var viewModel = new GalleryViewModel()
            {
                Gallery = gallery,
                RandomEntry = _requestDataRepository.GetRandomEntry(),
                ContentSubcategories = _requestDataRepository.GetContentSubcategoriesByParent_Gallery(gallery.CategoryId)
            };

            if (viewModel.Gallery == null)
                RedirectToAction("NoContent", "Home");

            _galleriesService.GeneratePictureUrls(viewModel.Gallery);

            return View(viewModel);
        }

        public ActionResult Category(int id, int? page)
        {
            var viewModel = new GalleriesViewModel
            {
                Galleries = _requestDataRepository.GetGalleriesByCategoryAndCreateDateDesc(id),
                RandomEntry = _requestDataRepository.GetRandomEntry(),
                ContentSubcategories = _requestDataRepository.GetContentSubcategoriesByParent_Gallery(id)
            };

            if (viewModel.Galleries.Count == 0)
                RedirectToAction("NoContent", "Home");

            foreach (var gallery in viewModel.Galleries)
                _galleriesService.GeneratePictureUrls(gallery);

            return View(viewModel);
        }

        public ActionResult Subcategory(int id, int? page)
        {
            var galleries = _requestDataRepository.GetGalleriesBySubcategoryAndCreateDateDesc(id);

            if (galleries == null)
                return RedirectToAction("NoContent", "Home");

            var contentSubCategories = _requestDataRepository.GetContentSubcategoriesByParent_Gallery(galleries.First().CategoryId);

            var viewModel = new GalleriesViewModel
            {
                Galleries = galleries,
                RandomEntry = _requestDataRepository.GetRandomEntry(),
                ContentSubcategories = contentSubCategories
            };

            foreach (var gallery in viewModel.Galleries)
                _galleriesService.GeneratePictureUrls(gallery);

            return View(viewModel);
        }
    }
}