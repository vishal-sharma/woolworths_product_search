using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoolworthsProductSearch.Models;
using WoolworthsProductSearch.Services;

namespace WoolworthsProductSearch.Controllers
{
    [Produces("application/json")]
    [Route("api/SearchSpecials")]
    public class SearchSpecialsController : Controller
    {
        // GET api/searchspecials/5
        [HttpGet("{productName}")]
        public async Task<IEnumerable<Product>> Get(string productName)
        {
            var searchService = new ProductSearchService();
            var products =  await searchService.Search(productName);
            return products.Where(x => x.IsOnSpecial);
        }
    }
}