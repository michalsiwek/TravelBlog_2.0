﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using TravelBlog.Infrastructure;
using TravelBlog.Models;

namespace TravelBlog.Repository
{
    public interface IRequestDataRepository
    {
        List<T> GetElements<T>();
        T GetElement<T>(int id);
        List<Entry> GetTop3EntriesByCreateDate();
        List<Entry> GetEntriesByCreateDateDesc();
        List<Entry> GetEntriesByCategoryAndCreateDateDesc(string categoryName);
    }

    public class RequestDataRepository : IRequestDataRepository
    {
        private readonly string _serverAddress;

        private readonly IRequestService _requestService;

        public RequestDataRepository()
        {
            _serverAddress = "http://localhost:49743/api";
            _requestService = new RequestService();
        } 

        public List<T> GetElements<T>()
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(T).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<T>>(jsonStr);

                return output;
            }
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

        public List<Entry> GetEntriesByCategoryAndCreateDateDesc(string categoryName)
        {
            using (var client = new WebClient())
            {
                var elementType = _requestService.GetTypeRoute(typeof(Entry).Name);
                var requestsData = client.DownloadData($"{_serverAddress}/{elementType}");

                string jsonStr = Encoding.UTF8.GetString(requestsData);
                var output = JsonConvert.DeserializeObject<List<Entry>>(jsonStr)
                    .Where(p => p.CategoryName.ToLower().Equals(categoryName.ToLower()))
                    .OrderByDescending(p => p.CreateDate)
                    .ToList();

                return output;
            }
        }

    }
}