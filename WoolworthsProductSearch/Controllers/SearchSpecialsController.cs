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
        [HttpGet("product/{productName}")]
        public async Task<IEnumerable<Product>> GetSpecialsByProductName(string productName)
        {
            var searchService = new ProductSearchService();
            var products = await searchService.Search(productName);
            return products.Where(x => x.IsOnSpecial);
        }

        [HttpGet("{category}")]
        public async Task<IEnumerable<Product>> GetSpecialsByCategory(string category = null)
        {
            var searchService = new ProductSearchService();
            var products = await searchService.SearchSpecials(category);
            return products.Where(x => x.IsOnSpecial);
        }
    }
}