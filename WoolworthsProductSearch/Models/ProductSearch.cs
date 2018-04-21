namespace WoolworthsProductSearch.Models
{
    public class ProductSearch
    {
        public string SearchTerm { get; set; }
        public string SortType => "TraderRelevance";
    }
}
