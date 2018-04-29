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
        private Uri baseAddress = new Uri("https://www.woolworths.com.au/apis/ui/Search/");

        // search from https://www.woolworths.com.au/shop/search/products?searchTerm=smith%20chips
        public async Task<IEnumerable<Product>> Search(string productName)
        {
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

        private void SetCookies(CookieContainer cookieContainer)
        {
            var cookieCopied = @"ASP.NET_SessionId=yvynsfkyxoygrv4icz44v1vp; w-rsjhf=PGcgdD0iOWZlY2IwMmVlOTQxNGQzY2IzMWE5NzI4ZDY1YzNmMjFnaXpkaXJndWxlIiAvPg==; ARRAffinity=2bc54e4d044ced332ea3aae306cbc27d4c0b6f28e34dc26f8098205225685c6b; check=true; AMCVS_4353388057AC8D357F000101%40AdobeOrg=1; cvo_sid1=9Z53JQYR9GPY;";
            var cookies = cookieCopied.Split("; ");
            foreach (string cookieKeyValue in cookies)
            {
                var cookie = cookieKeyValue.Split('=');
                cookieContainer.Add(baseAddress, new Cookie(cookie[0], cookie[0]));
            }

        }
    }
}

