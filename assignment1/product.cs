
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace assignment1 { 
class Product
{

    private Product product;

    public Product(Product product)
    {
        this.product = product;
    }

    public int ID { get; set; }
    public string Store { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int CurrentStock { get; set; }
    public bool StockAvailable { get; set; }
        public int Price { get; set; }
    }
}
