using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WoolworthsProductSearch.Models;

namespace WoolworthsProductSearch.Services
{
    public class ProductSearchService
    {
        // search from https://www.woolworths.com.au/shop/search/products?searchTerm=smith%20chips
        public async Task<IEnumerable<Product>> Search(string productName)
        {
            Uri baseAddress = new Uri("https://www.woolworths.com.au/apis/ui/Search/");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(new LoggingHandler(handler)) { BaseAddress = baseAddress })
            {
                //SetCookies(cookieContainer);

                var productSearch = new ProductSearch { SearchTerm = productName };
                HttpResponseMessage response = await client.PostAsJsonAsync("products", productSearch);
                var productsn = await response.Content.ReadAsStringAsync();
                var productList = JObject.Parse(productsn)["Products"].Select(x => x.ToObject<RootObject>());
                return productList.Select(x => x.Products.First());
            }
        }

        public async Task<IEnumerable<Product>> SearchSpecials(string category)
        {
            Uri baseAddress = new Uri("https://www.woolworths.com.au/apis/ui/browse/");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(new LoggingHandler(handler)) { BaseAddress = baseAddress })
            {
                var specialsSearch = GetSpecialsSearchParam(category);
                HttpResponseMessage response = await client.PostAsJsonAsync("category", specialsSearch);
                var productsn = await response.Content.ReadAsStringAsync();
                var productList = JObject.Parse(productsn)["Bundles"].Select(x => x.ToObject<RootObject>());
                return productList.Select(x => x.Products.First());
            }
        }

        private SpecialsSearch GetSpecialsSearchParam(string category)
        {
            // based on results of https://www.woolworths.com.au/apis/ui/PiesCategoriesWithSpecials/ api call
            switch (category.ToLower())
            {
                case ("bakery"):
                    return new SpecialsSearch("bakery", "specialsgroup.1292.1_DEB537E");
                case ("fridge"):
                    return new SpecialsSearch("dairy-eggs-fridge", "specialsgroup.1292.1_6E4F4E4");
                case ("pantry"):
                    return new SpecialsSearch("pantry", "specialsgroup.1292.1_39FD49C");
                case ("freezer"):
                    return new SpecialsSearch("freezer", "specialsgroup.1292.1_ACA2FC2");
                case ("drinks"):
                    return new SpecialsSearch("drinks", "specialsgroup.1292.1_5AF3A0A");
                case ("pet"):
                    return new SpecialsSearch("pet", "specialsgroup.1292.1_61D6FEB");
                case ("health-beauty"):
                    return new SpecialsSearch("health-beauty", "specialsgroup.1292.1_894D0A8");
                case ("household"):
                    return new SpecialsSearch("household", "specialsgroup.1292.1_2432B58");
                case ("lunchbox"):
                    return new SpecialsSearch("lunch-box", "specialsgroup.1292.1_9E92C35");
            }
            return new SpecialsSearch();
        }
    }
}

