using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{ 
public class RetailPro

{
        RetailPro() { }

        public RetailPro(int ID, string ProductName, int CurrentStock, int Request,int Price)
    {
        this.ID = ID;
        this.ProductName = ProductName;
        this.CurrentStock = CurrentStock;
            this.Request = Request;

            this.Price = Price;
           
        List<RetailPro> retailPro = new List<RetailPro> { new RetailPro() { } };
    }

    public int ID { get; set; }
    public string ProductName { get; set; }
    public int CurrentStock { get; set; }
    public int Request { get; set; }
   public int Price { get; set; }
    }
}