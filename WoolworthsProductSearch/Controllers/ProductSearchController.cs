using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WoolworthsProductSearch.Models;
using WoolworthsProductSearch.Services;

namespace WoolworthsProductSearch.Controllers
{
    [Route("api/[controller]")]
    public class ProductSearchController : Controller
    {

        // GET api/values/5
        [HttpGet("{productName}")]
        public async Task<JObject> Get(string productName)
        {
            var searchService = new ProductSearchService();
            return await searchService.Search(productName);
        }
    }
}
