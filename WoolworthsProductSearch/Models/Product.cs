using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoolworthsProductSearch.Models
{
    public class ProductResult
        {
        public ProductResult(RootObject obj)
        {

        }
        }
    public class Product
    {
        public int Stockcode { get; set; }
        public string Barcode { get; set; }
        public double CupPrice { get; set; }
        public string CupMeasure { get; set; }
        public string CupString { get; set; }
        public bool HasCupPrice { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SmallImageFile { get; set; }
        public bool IsNew { get; set; }
        public bool IsOnSpecial { get; set; }
        public bool IsEdrSpecial { get; set; }
        public double SavingsAmount { get; set; }
        public double WasPrice { get; set; }
        public bool IsInStock { get; set; }
        public string Brand { get; set; }
    }

    public class RootObject
    {
        public List<Product> Products { get; set; }
        public string Name { get; set; }
    }
}
