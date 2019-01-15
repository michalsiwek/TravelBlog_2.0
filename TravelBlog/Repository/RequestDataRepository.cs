using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Antlr.Runtime.Tree;
using Newtonsoft.Json;
using TravelBlog.Helpers;
using TravelBlog.Infrastructure;
using TravelBlog.Models;

namespace TravelBlog.Repository
{
    public interface IRequestDataRepository
    {
        //List<T> GetElements<T>();
        T GetElement<T>(int id);

        // Entries
        Entry GetRandomEntry();
        List<Entry> GetTop3EntriesByCreateDate();
        List<Entry> GetEntriesByCreateDateDesc();
        List<Entry> GetEntriesByCategoryAndCreateDateDesc(int catId);
        List<Entry> GetEntriesBySubcategoryAndCreateDateDesc(int catId);

        // Galleries
        List<Gallery> GetGalleriesByCreateDateDesc();
        List<Gallery> GetGalleriesByCategoryAndCreateDateDesc(int catId);
        List<Gallery> GetGalleriesBySubcategoryAndCreateDateDesc(int catId);

        // Categories
        List<ContentCategory> GetContentCategories_Entry();
        List<ContentSubcategory> GetContentSubcategoriesByParent_Entry(int catId);
        List<ContentCategory> GetContentCategories_Gallery();
        List<ContentSubcategory> GetContentSubcategoriesByParent_Gallery(int catId);
    }

    public class RequestDataRepository : IRequestDataRepository
    {
        private readonly string _serverAddress;

        private readonly IRequestService _requestService;

        public RequestDataRepository()
        {
            _serverAddress = ConnectionFactory.GetServerAddress() + "/api";
            _requestService = new RequestService();
        }

        public T GetElement<T>(int id)
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(T).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}/{id}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<T>(jsonStr);

                return output;
            }
        }

        #region Entries

        public Entry GetRandomEntry()
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(Entry).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert
                    .DeserializeObject<List<Entry>>(jsonStr)
                    .Where(e => !string.IsNullOrEmpty(e.ImageUrl))
                    .ToList();

                return output.GetRandomElement();
            }
        }

        public List<Entry> GetTop3EntriesByCreateDate()
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(Entry).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<Entry>>(jsonStr)
                    .OrderByDescending(p => p.CreateDate)
                    .Take(3)
                    .ToList();

                return output;
            }
        }

        public List<Entry> GetEntriesByCreateDateDesc()
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(Entry).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<Entry>>(jsonStr)
                    .OrderByDescending(p => p.CreateDate)
                    .ToList();

                return output;
            }
        }

        public List<Entry> GetEntriesByCategoryAndCreateDateDesc(int catId)
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(Entry).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<Entry>>(jsonStr)
                    .Where(p => p.CategoryId == catId)
                    .OrderByDescending(p => p.CreateDate)
                    .ToList();

                return output;
            }
        }

        public List<Entry> GetEntriesBySubcategoryAndCreateDateDesc(int catId)
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(Entry).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<Entry>>(jsonStr)
                    .Where(p => p.SubcategoryId == catId)
                    .OrderByDescending(p => p.CreateDate)
                    .ToList();

                return output;
            }
        }

        #endregion

        #region Galleries

        public List<Gallery> GetGalleriesByCreateDateDesc()
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(Gallery).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<Gallery>>(jsonStr)
                    .OrderByDescending(p => p.CreateDate)
                    .ToList();

                return output;
            }
        }

        public List<Gallery> GetGalleriesByCategoryAndCreateDateDesc(int catId)
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(Gallery).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<Gallery>>(jsonStr)
                    .Where(p => p.CategoryId == catId)
                    .OrderByDescending(p => p.CreateDate)
                    .ToList();

                return output;
            }
        }

        public List<Gallery> GetGalleriesBySubcategoryAndCreateDateDesc(int catId)
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(Gallery).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<Gallery>>(jsonStr)
                    .Where(p => p.SubcategoryId == catId)
                    .OrderByDescending(p => p.CreateDate)
                    .ToList();

                return output;
            }
        }

        #endregion

        #region Categories

        public List<ContentCategory> GetContentCategories_Entry()
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(ContentCategory).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}/Entries");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<ContentCategory>>(jsonStr)
                    .ToList();

                return output;
            }
        }

        public List<ContentSubcategory> GetContentSubcategoriesByParent_Entry(int catId)
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(ContentSubcategory).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}/Entries/{catId}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<ContentSubcategory>>(jsonStr)
                    .ToList();

                return output;
            }
        }

        public List<ContentCategory> GetContentCategories_Gallery()
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(ContentCategory).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}/Galleries");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<ContentCategory>>(jsonStr)
                    .ToList();

                return output;
            }
        }

        public List<ContentSubcategory> GetContentSubcategoriesByParent_Gallery(int catId)
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(ContentSubcategory).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}/Galleries/{catId}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<ContentSubcategory>>(jsonStr)
                    .ToList();

                return output;
            }
        }

        #endregion

    }
}