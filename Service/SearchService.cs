using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimonsVoss.IService;
using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimonsVoss.Service
{
    public class SearchService : ISearchService
    {

        private const string URL = "https://simonsvoss-homework.herokuapp.com/sv_lsm_data.json";
        public  JObject Search()
        {
            var result = new JObject();
            using (var client = new WebClient())
            {
                var content =   client.DownloadString(URL);
                result = JObject.Parse(content);
            }
            return result;
        }

        public JsonData Desrliaze<T>(JObject content)
        {
            return JsonConvert.DeserializeObject<JsonData>(content.ToString());
        }
    }
}
