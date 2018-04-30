using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoolworthsProductSearch.Models
{
    public class SpecialsSearch
    {
        public SpecialsSearch()
            : this("", "specialsgroup.1292")
        { }

        public SpecialsSearch(string categoryName, string categoryId, int pageSize = 36, int pageNumber = 1)
        {
            var formatObjectValue = categoryName == string.Empty ? "Half Price" : categoryName;
            Url = "/shop/browse/specials/half-price/" + categoryName;
            CategoryId = categoryId;
            PageNumber = pageNumber;
            PageSize = pageSize;
            FormatObject = "{\"name\":\"" + formatObjectValue + "\"}";
        }

        public string CategoryId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortType => "TraderRelevance";

        public string Url { get; set; }

        public string FormatObject { get; set; }
    }
}
