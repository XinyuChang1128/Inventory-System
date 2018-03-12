using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using assignment1;

namespace assignment1
{
    class franchise : Menu
    {

        public static List<Product> DisplayInventory(string place)
        {
            Console.WriteLine("Please input the stock");
            int stocknumber = int.Parse(System.Console.ReadLine());

            string StockRequest = File.ReadAllText(place + "_inventory.json");
            var stockrequesttojson = Newtonsoft.Json.JsonConvert.SerializeObject(StockRequest);
            var stocks = JsonConvert.DeserializeObject<List<Product>>(StockRequest);
            Console.WriteLine("ID     Product   Current Stock  Re-Stock      Price");
            Console.WriteLine("===============================================");
            foreach (var showallproducts in stocks)
            {
                if (showallproducts.CurrentStock > stocknumber)
                {
                    bool restock = false;
                    Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + "\t" + showallproducts.CurrentStock + "\t" + restock + "\t" + "\t" + showallproducts.Price + "\n"));
                }
                else
                {
                    bool restock = true;
                    Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + "\t" + showallproducts.CurrentStock + "\t" + restock + "\t" + "\t" + showallproducts.Price + "\n"));
                }

            }
            Console.WriteLine("Please input need stock product id");
            int restockid = int.Parse(System.Console.ReadLine()) - 1;
            Console.WriteLine("Please input how many stock you want");
            int needstock = int.Parse(System.Console.ReadLine());
            Console.Clear();
            if (stocks[restockid].CurrentStock < stocknumber)
            {
                int now = stocks[restockid].CurrentStock;
                stocks[restockid].CurrentStock = now + needstock;
                //Console.WriteLine(stocks[restockid].CurrentStock);
                Console.WriteLine(stocks[restockid].ID + "\t" + "already increase restock now");
                bool restock = false;
                Console.WriteLine("ID     Product   Current Stock  Re-Stock      Price");
                Console.WriteLine("===============================================");
                foreach (var showallproducts in stocks)
                {
                    Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + "\t" + showallproducts.CurrentStock + "\t" + restock + "\t" + "\t" + showallproducts.Price + "\n"));
                }
            }
            //FALSE
            else
            {
                int now = stocks[restockid].CurrentStock;
                stocks[restockid].CurrentStock = needstock + now;
                Console.WriteLine("this has enought stock,but still input the stock ");
              
                Console.WriteLine("ID     Product   Current Stock  Re-Stock      Price");
                Console.WriteLine("===============================================");
                foreach (var showallproducts in stocks)
                {
                    if (showallproducts.CurrentStock > stocknumber)
                    {
                        bool restock = false;
                        Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + "\t" + showallproducts.CurrentStock + "\t" + restock + "\t" + "\t" + showallproducts.Price + "\n"));
                    }
                    else
                    {
                        bool restock = true;
                        Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + "\t" + showallproducts.CurrentStock + "\t" + restock + "\t" + "\t" + showallproducts.Price + "\n"));
                    }
                }
            }
            File.WriteAllText(place + "_inventory.json", JsonConvert.SerializeObject(stocks, Formatting.Indented));
            Console.WriteLine("Do you want to choose other item for restock");
            String i7 = System.Console.ReadLine();
            switch (i7)
            {
                case "Y":
                case "y":
                case "yes":
                    DisplayInventory(place);
                    break;
                case "N":
                case "n":
                case "no":
                    Franchise(place);
                    break;
                default:
                    Console.WriteLine("wrong option.");

                    break;
            }
            Console.ReadKey();
            return stocks;
        }


        public static void DisplayLow(string place)
        {
            Console.WriteLine("Please input Low or High");
            String loworfalse = System.Console.ReadLine();
   
            string StockRequest = File.ReadAllText(place + "_inventory.json");
            var stockrequesttojson = Newtonsoft.Json.JsonConvert.SerializeObject(StockRequest);
            var stocks = JsonConvert.DeserializeObject<List<Product>>(StockRequest);
            //Display the low 
            switch (loworfalse)
            {
                case "Low":
                case "LOW":
                case "low":
                case "l":
                case "L":
                    Console.WriteLine("Please input the stock");
                    int stocknumber = int.Parse(System.Console.ReadLine());

                    foreach (var showallproducts in stocks)
                    {
                        if (showallproducts.CurrentStock > stocknumber)
                        {
                            // bool restockfalse = false;
                            // Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + showallproducts.CurrentStock + "\t" + restockfalse + "\n"));
                        }
                        else
                        {
                            bool restocktrue = true;
                            Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + "\t" + showallproducts.CurrentStock + "\t" + restocktrue + "\t"+showallproducts.Price+"\n"));
                            if (showallproducts.ProductName == " ")
                            {
                                Console.WriteLine("It is empty");
                                Console.WriteLine("Do you want to choose other item for restock");
                                String i8 = System.Console.ReadLine();
                                switch (i8)
                                {
                                    case "Y":
                                    case "y":
                                    case "YES":
                                    case "yes":
                                        DisplayLow(place);
                                        break;
                                    case "N":
                                    case "No":
                                    case "n":
                                    case "no":
                                        Franchise(place);
                                        break;
                                    default:
                                        Console.WriteLine("wrong option.");

                                        break;
                                }
                            }

                        }

                    }
                    Console.WriteLine("Please input need stock product id");
                    int restockid = int.Parse(System.Console.ReadLine()) - 1;
                    Console.WriteLine("Please input how many stock you want");
                    int needstock1 = int.Parse(System.Console.ReadLine());
                    stocks[restockid].CurrentStock = stocks[restockid].CurrentStock + needstock1;

                    Console.WriteLine(stocks[restockid].ID + "\t" + "do not need restock now");

                    File.WriteAllText(place + "_inventory.json", JsonConvert.SerializeObject(stocks, Formatting.Indented));
                    Console.WriteLine("Do you want to choose other item for restock");
                    string i7 = System.Console.ReadLine();
                    switch (i7)
                    {

                        case "Y":
                        case "y":
                        case "yes":
                        case "YES":
                        case "Yes":
                            DisplayLow(place);
                            break;

                        case "N":
                        case "n":
                        case "no":
                        case "NO":
                        case "No":
                            Franchise(place);
                            break;
                        default:
                            Console.WriteLine("wrong option.");

                            break;
                    }
                    break;
                //Display the high
                case "High":
                case "H":
                case "HIGH":
                case "high":

                    {
                        Console.WriteLine("Please input the stock");
                        int stocknumber2 = int.Parse(System.Console.ReadLine());
                        Console.WriteLine("ID     Product   Current Stock  Re-Stock      Price");
                        Console.WriteLine("===============================================");
                        foreach (var showallproducts in stocks)
                        {
                            if (showallproducts.CurrentStock > stocknumber2)
                            {
                                bool restockfalse = false;
                                Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + "\t" + showallproducts.CurrentStock + "\t" + restockfalse + "\t"+showallproducts.Price + "\n"));
                            }
                            else
                            {
                                //bool restocktrue = true;
                                //Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + showallproducts.CurrentStock + "\t" + restocktrue + "\n"));
                            }

                        }
                        Console.WriteLine("Please input need stock product id");
                        int restockid2 = int.Parse(System.Console.ReadLine()) - 1;

                        stocks[restockid2].CurrentStock = stocknumber2 + stocks[restockid2].CurrentStock;

                        foreach (var showallproducts in stocks)
                        {
                            bool restock2 = false;
                            Console.Write((showallproducts.ID + "\t" + showallproducts.ProductName + "\t" + showallproducts.CurrentStock + "\t" + restock2 + "\n"));
                        }
                        File.WriteAllText(place + "_inventory.json", JsonConvert.SerializeObject(stocks, Formatting.Indented));

                        Console.WriteLine("Do you want to choose other item for restock");
                        String i8 = System.Console.ReadLine();
                        switch (i8)
                        {
                            case "Y":
                            case "y":
                            case "YES":
                            case "yes":
                                DisplayLow(place);
                                break;
                            case "N":
                            case "No":
                            case "n":
                            case "no":
                                Franchise(place);
                                break;
                            default:
                                Console.WriteLine("wrong option.");

                                break;
                        }
                    }
                    break;
            }
        }
        public static void Display(string place)
        {
            string fi = File.ReadAllText("owners_inventory.json");
            string newfu = fi.Replace("][", ",");
            var A = JsonConvert.SerializeObject(newfu, Formatting.Indented);
            var BB = JsonConvert.DeserializeObject<List<Product>>(newfu);

            foreach (var abc2 in BB)
            {

                string cbd = place;
                if (abc2.Store == cbd)
                {
                    Console.Write((abc2.ID + "\t" + abc2.Store + "\t" + abc2.ProductName + "\t" + abc2.Quantity + "\t" + abc2.CurrentStock + "\t" + abc2.StockAvailable + "\n"));

                    //above only have the CBD now
                    // newowner.Add(abc2);
                    string CBDinventoryFile = File.ReadAllText(place + "_inventory.json");
                    string cbd123 = fi.Replace("][", ",");
                    var CBDinventory = JsonConvert.DeserializeObject<List<Product>>(cbd123);
                    /*
                    foreach (var add in CBDinventory)
                    {


                        List<Product> ownerinventory = new List<Product> { abc2 };
                        List<Product> CBDInventory = new List<Product> { add };
                       /* Try to compare the two file 
                        var NEW = ownerinventory.Except(CBDInventory).ToList();

                        NEW.ForEach(x =>
                        {
                            Console.WriteLine(x.ID + " " + x.Store + " " + x.ProductName + " " + x.CurrentStock);
                            StreamWriter OwnersInventory = new StreamWriter(place+"_inventory.json", true);
                            List<Product> selectproduct = new List<Product> { x };
                            //selectproduct.Add(showpro[selectnumber]);
                            //if showpro[selectnumber] is string
                            var AA = JsonConvert.SerializeObject(selectproduct, Formatting.Indented);
                            OwnersInventory.Write(AA);
                            OwnersInventory.Close();
                        });
                        //Console.WriteLine(NEW);zzzz
                        Console.ReadKey();

                    }
                    */
                }
                

            }
            Console.ReadKey();
        }
    }
}

