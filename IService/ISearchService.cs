using Newtonsoft.Json.Linq;
using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.IService
{
    public interface ISearchService
    {
        JObject Search();
        JsonData Desrliaze<T>(JObject content);

    }
}
