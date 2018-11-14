using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Configuration;

namespace NTTDATA_Web
{
    public class ApiClient : HttpClient
    {
        private string baseUrl;

        public ApiClient(string requestUrl, string methodType)
        {
            baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            string completeUrl = baseUrl + requestUrl;

            //Passing service base url  
            BaseAddress = new Uri(baseUrl);
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}