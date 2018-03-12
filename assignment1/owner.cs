using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace assignment1
{
    class onwer : Menu
    {

        //Display the all requeststock
        static List<Product> ReadStock()
        {

            Console.WriteLine("ID      Store  Product  Quantity   Current Stock    Stock Avaliable     Price");
            Console.WriteLine("=============================================================================");
            string StockRequest = File.ReadAllText("stockrequests.json");

            var stockrequesttojson = Newtonsoft.Json.JsonConvert.SerializeObject(StockRequest);
            var stocks = JsonConvert.DeserializeObject<List<Product>>(StockRequest);
            foreach (var showallproducts in stocks)
            {
                int prototalPrice = showallproducts.Quantity * showallproducts.Price;
                Console.Write((showallproducts.ID + "\t" + showallproducts.Store + "\t" + showallproducts.ProductName + "\t" + showallproducts.Quantity + "\t" + "\t" + showallproducts.CurrentStock + "\t" + "\t" + showallproducts.StockAvailable + "\t" + "\t" + prototalPrice + "\n"));

            }
            Console.Write("\n" + "Please enter the product ID ( entre  0  to back last menu)" + "\n");
            return stocks;
        }
        //Show all stock requestes
        public static void AllStock()
        {
            Console.WriteLine("Display All Stock Requests");
            ReadStock();         
            StockRequest();
            Console.WriteLine("Do you want to return to last menu?      Y/N");
            string returntolast = Console.ReadLine();
            switch (returntolast)
            {
                case "Y":
                case "y":
                case "yes":
                case "YES":
                case "Yes":
                    Console.Clear();
                    ReadStock();
                    StockRequest();

                    break;
                case "N":
                case "n":
                case "no":
                case "NO":
                case "No":
                    Console.Clear();
                    ownermenu();
                    break;
                default:
                    Console.WriteLine("Wrong option.");
                    break;
            }

        }
        public static void StockRequests()
        {
            Console.WriteLine("Enter Request to process:  True/False");
            string trueorfalse =Console.ReadLine();
            switch (trueorfalse)
            {
                case "T":
                case "t":
                case "True":
                case "true":
                    Console.Clear();
                    Console.WriteLine("ID      Store  Product  Quantity   Current Stock    Stock Avaliable    Price");
                    Console.WriteLine("=============================================================================");
                    ReadREQUESTTrue();
                    break;
                case "F":
                case "False":
                case "f":
                case "false":
                    Console.Clear();
                    Console.WriteLine("ID      Store  Product  Quantity   Current Stock    Stock Avaliable    Price");
                    Console.WriteLine("==================================================================================");
                    ReadREQUESTFalse();
                    break;
                default:
                    Console.WriteLine("Wrong option.");
                    break;
            }
        }


      

        //Display the stockrequest and people can choose the stock
        public static void StockRequest()
        {  
            int idnumber = int.Parse(System.Console.ReadLine());
            if (idnumber == 0)
            {
                Console.Clear();
                ownermenu();
            }
            string fi = File.ReadAllText("stockrequests.json");
            var showpro = JsonConvert.DeserializeObject<List<Product>>(fi);
            int selectnumber = idnumber - 1;

            bool available = true;
            if (showpro[selectnumber].StockAvailable == available)
            {
                showpro[selectnumber].CurrentStock = showpro[selectnumber].CurrentStock - showpro[selectnumber].Quantity;
                if (showpro[selectnumber].Quantity > showpro[selectnumber].CurrentStock)
                {
                    showpro[selectnumber].StockAvailable = false;
                    File.WriteAllText("stockrequests.json", JsonConvert.SerializeObject(showpro, Formatting.Indented));
          
                    Console.WriteLine("This product will not have enough stock");
                    StreamWriter OwnersInventory = new StreamWriter("owners_inventory.json", true);
                    List<Product> selectproduct = new List<Product> { (showpro[selectnumber]) };
                    //selectproduct.Add(showpro[selectnumber]);
                    //if showpro[selectnumber] is string
                    var AA = JsonConvert.SerializeObject(selectproduct, Formatting.Indented);
                    if (AA.Contains(showpro[selectnumber].ProductName))
                    {
                        showpro[selectnumber].CurrentStock = showpro[selectnumber].CurrentStock;
                    }
                    OwnersInventory.Write(AA);
                    OwnersInventory.Close();





                    Console.WriteLine("Do you want to choose other items?      Y/N");
                    string i5 = Console.ReadLine();
                    switch (i5)
                    {
                        case "Y":
                        case "y":
                        case "yes":
                        case "YES":
                        case "Yes":
                            Console.Clear();
                            ReadStock();
                            StockRequest();

                            break;
                        case "N":
                        case "n":
                        case "no":
                        case "NO":
                        case "No":
                            Console.Clear();
                            ownermenu();
                            break;
                        default:
                            Console.WriteLine("wrong option.");
                            break;
                    }
                }
                else
                {

                    Console.WriteLine(showpro[selectnumber].ID + "\t" + showpro[selectnumber].Store + "\t" + showpro[selectnumber].ProductName + "\t" + showpro[selectnumber].Quantity + "\t" + showpro[selectnumber].CurrentStock + "\t"  +"\t" + showpro[selectnumber].Price+ "\n");
                    File.WriteAllText("stockrequests.json", JsonConvert.SerializeObject(showpro, Formatting.Indented));
                    //Creat owners_inventory json file
                    StreamWriter OwnersInventory = new StreamWriter("owners_inventory.json", true);
                    List<Product> selectproduct = new List<Product> { (showpro[selectnumber]) };
                    //selectproduct.Add(showpro[selectnumber]);
                    //if showpro[selectnumber] is string
                    var AA = JsonConvert.SerializeObject(selectproduct, Formatting.Indented);
                    if (AA.Contains(showpro[selectnumber].ProductName)) {
                        showpro[selectnumber].CurrentStock = showpro[selectnumber].CurrentStock;
                    }
                    OwnersInventory.Write(AA);
                    OwnersInventory.Close();

                    Console.WriteLine("Do you want to choose other items?      Y/N");
                    string i5 = Console.ReadLine();
                    switch (i5)
                    {
                        case "Y":
                        case "y":
                        case "yes":
                        case "YES":
                        case "Yes":

                            Console.Clear();
                            ReadStock();
                            StockRequest();

                            break;
                        case "N":
                        case "n":
                        case "no":
                        case "NO":
                        case "No":
                            Console.Clear();
                            ownermenu();
                            break;
                        default:
                            Console.WriteLine("wrong option.");
                            break;
                    }
                    //File.WriteAllText("owner_inventory.json", JsonConvert.SerializeObject(showpro[selectnumber], Formatting.Indented));
                }

            }
            else
            {
                Console.WriteLine("Do not have eought stock");

                /*StreamWriter OwnersInventory = new StreamWriter("owners_inventory.json", true);
                List<Product> selectproduct = new List<Product> { showpro[selectnumber] };
                //selectproduct.Add(showpro[selectnumber]);
                //if showpro[selectnumber] is string
                var AA = JsonConvert.SerializeObject(selectproduct, Formatting.Indented);
                OwnersInventory.Write(AA);
                OwnersInventory.Close();*/

                Console.WriteLine("Do you want to choose other items?      Y/N");
                string i5 = Console.ReadLine();
                switch (i5)
                {
                    case "Y":
                    case "y":
                    case "yes":
                    case "YES":
                    case "Yes":
                        Console.Clear();
                        ReadStock();
                        StockRequest();

                        break;
                    case "N":
                    case "n":
                    case "no":
                    case "NO":
                    case "No":
                        Console.Clear();
                        ownermenu();
                        break;
                    default:
                        Console.WriteLine("wrong option.");
                        break;
                }

              
            }
            return;
        }


       
        //Only display the stockavailable which is true 
        public static void ReadREQUESTTrue()
        {
            string readrequest = File.ReadAllText("stockrequests.json");
            var resultread = Newtonsoft.Json.JsonConvert.SerializeObject(readrequest);
            var proresu = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(readrequest);
            var aaaa = JsonConvert.DeserializeObject<List<Product>>(readrequest);
            var showpro = JsonConvert.DeserializeObject<List<Product>>(readrequest);
            for (int i = 0; i < 15; i++)
            {
                if (showpro[i].StockAvailable == true)
                {
                    int prototalPrice = showpro[i].Quantity * showpro[i].Price;
                    Console.Write((showpro[i].ID + "\t" + showpro[i].Store + "\t" + showpro[i].ProductName + "\t" + showpro[i].Quantity + "\t" + "\t" + showpro[i].CurrentStock + "\t" + "\t" + showpro[i].StockAvailable +"\t" + "\t" + prototalPrice+"\n"));
                }
            }
            Console.WriteLine("Back to the last menu:  Yes/No ");
            Console.WriteLine("chose 'No' to start select items " + "\n");
            string yesorno2 = Console.ReadLine();
            switch (yesorno2)
            {
                case "y":
                case "Y":
                case "Yes":
                case "yes":
                case "YES":
                    Console.Clear();
                    ownermenu();
                    break;
                case "n":
                case "N":
                case "No":
                case "no":
                case "NO":
                    Console.WriteLine("Please select one item,input ID");
                    //StockRequest();
                    StockRequests();
                    break;
            }
        }
        //Only display the stockavailable which is false
        public static void ReadREQUESTFalse()
        {
            string readrequest = File.ReadAllText("stockrequests.json");
            var resultread = Newtonsoft.Json.JsonConvert.SerializeObject(readrequest);
            var proresu = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(readrequest);
            var aaaa = JsonConvert.DeserializeObject<List<Product>>(readrequest);
            var showpro = JsonConvert.DeserializeObject<List<Product>>(readrequest);
            for (int i = 0; i < 15; i++)
            {
                if (showpro[i].StockAvailable == false)
                {
                    int prototalPrice = showpro[i].Quantity * showpro[i].Price;
                    Console.Write((showpro[i].ID + "\t" + showpro[i].Store + "\t" + showpro[i].ProductName + "\t" + showpro[i].Quantity + "\t" + "\t" + showpro[i].CurrentStock + "\t" + "\t" + showpro[i].StockAvailable + "\t"+ "\t" + prototalPrice + "\n"));
                }
            }
            Console.WriteLine("Back to the last menu:  Yes/No "+"\n");
           
            string yesorno2 = Console.ReadLine();
            switch (yesorno2)
            {
                case "y":
                case "Y":
                case "Yes":
                case "yes":
                case "YES":
                    Console.Clear();
                    ownermenu();
                    break;
                case "n":
                case "N":
                case "No":
                case "no":
                case "NO":
                    Console.WriteLine("Please select one item,input ID");
                    StockRequest();
                    StockRequests();
                    break;
            }


         
        }
        
        
        // Display product which people selected before
        public static void AllProductLines()
        {
            Console.WriteLine("All Product Lines");
            Console.WriteLine("ID   Product    Current Stock  Price");
            Console.WriteLine("===========================================");
            AllProduct();
        }

        //Display the product which select before
        public static void AllProduct()
        {
            string fi = File.ReadAllText("owners_inventory.json");
            string newfu = fi.Replace("][", ",");
            var A = JsonConvert.SerializeObject(newfu, Formatting.Indented);
            var BB = JsonConvert.DeserializeObject<List<Product>>(newfu);
            foreach (var abc2 in BB)
            {
                int prototalPrice = abc2.Quantity * abc2.Price;
                List<Product> nosameproduct = BB.Where((x,i)=>BB.FindIndex(z=>z.ProductName==abc2.ProductName)==i).ToList();
                //Console.WriteLine(nosameproduct);
                Console.Write((abc2.ID + "\t" + abc2.ProductName + "\t" + "\t" + abc2.CurrentStock + "\t" + prototalPrice + "\n"));
            }
            Console.WriteLine("Do you want to back to the last menu?   Y/N");
            string yesorno2 = Console.ReadLine();
            switch (yesorno2)
            {
                case "y":
                case "Y":
                case "Yes":
                case "yes":
                case "YES":
                    Console.Clear();
                    ownermenu();
                    break;
                case "n":
                case "N":
                case "No":
                case "no":
                case "NO":
                    AllProductLines();
                    AllProduct();
                    break;
            }





          
        }
    }
}

    