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
    
    public class Retial : Menu
    {

        public static void displayProducts(string place, int n)
        {
            Display(place,n);
                }
        public static void Display(string place, int n) { 
            Console.Clear();
            Console.WriteLine("ID" + "\t" + "Product" + "\t" + "\t" + "Current Stock"+"\t"+"Price"+"\n");
            Console.WriteLine("======================================");
            ReadRetial(place, n);

            Console.WriteLine("[Legend: 'P' Next Page |'L' Last Page | 'R' Return to Menu | 'C' Complete Transaction]");
            Console.WriteLine("Enter Item Number to purchase or Function:");
            int x = 0;
            string s2 = Console.ReadLine();
            if ( Int32.TryParse(s2,out x))
            {

                PurchasesProduct( place, n,x);
            }
            else{
                switch (s2)
                {
                    case "P": case "p":
                        displayProducts(place, n + 5);
                        break;
                    case "l":
                    case "L":
                        displayProducts(place, n - 5);
                        break;
                    case "R": case "r":
                        Console.Clear();
                        retial(place);
                        break;
                    case "C":
                    case "c":
                        Console.Clear();
                        showWorkshop.printTicket(place);
                        
                        break;

                    default:
                        Console.WriteLine("wrong option");
                        break;
                }
            }
        }


        public static List<RetailPro> ReadRetial(string place, int n)


        {


            string store = File.ReadAllText("./"+place+ "_inventory.json");
           

            var rerelist = Newtonsoft.Json.JsonConvert.SerializeObject(store);
           
            var showpro = JsonConvert.DeserializeObject<List<RetailPro>>(store);
            int count = showpro.Count();
            for (int i = 0; i < n; i++)
            {
                if (n < count+1)
                {
                    if (showpro[i].ID > n - 5 && showpro[i].ID < n + 1)
                    {
                        Console.Write((showpro[i].ID + "\t" + showpro[i].ProductName + "\t" + "\t" + "\t" + showpro[i].CurrentStock + "\n"));

                    }
                }

                else
                {
                    Console.WriteLine("Please press any keys to returen to menu.");

                    string s3 = Console.ReadLine();
                    switch (s3)
                    {
                        case "":
                            Console.Clear();
                            retial(place);
                            break;
                        default:
                            Console.Clear();
                            retial(place);
                            break;

                    }
                }

            }
            return showpro;
        }
       static void PurchasesProduct(string place,int n,int x)
        {

            int selectNum = x;
            
            string store = File.ReadAllText("./" + place + "_inventory.json");
            var rerelist = Newtonsoft.Json.JsonConvert.SerializeObject(store);
            var showpro = JsonConvert.DeserializeObject<List<RetailPro>>(store);

            int wksID = selectNum - 1;

            if (showpro[wksID].CurrentStock > 0)
            {
                Console.WriteLine("Enter requers of product:");
                int reqNum = int.Parse(Console.ReadLine());
                if (showpro[wksID].CurrentStock>= reqNum)
                {
                    showpro[wksID].CurrentStock = showpro[wksID].CurrentStock - reqNum;
                    showpro[wksID].Request = reqNum;
                    File.WriteAllText("./" + place + "_inventory.json", JsonConvert.SerializeObject(showpro, Formatting.Indented));
                    List<RetailPro> selectproduct = new List<RetailPro> { (showpro[wksID]) };
                    StreamWriter OwnersInventory = new StreamWriter("ticket.json", true);

                    var AA = JsonConvert.SerializeObject(selectproduct, Formatting.Indented);

                    OwnersInventory.Write(AA);
                    OwnersInventory.Close();
                    Console.Write("purchasses is succeed." + "\n");

                    Console.WriteLine("Do u want keep purchassing?(Y/N)");

                    string p = Console.ReadLine();
                    switch (p)
                    {
                        case "Y":
                        case "y":
                      
                            Console.Clear();
                            displayProducts(place, n);
                            break;
                        case "N":
                        case "n":
                            Console.Clear();
                            retial(place);
                            break;
                        default:
                            Console.WriteLine("wrong option.");
                            break;

                    }
                }
           else
                {
                    Console.WriteLine("Stock not enough, please enter requers again:");
                    reqNum = int.Parse(Console.ReadLine());
                    showpro[wksID].CurrentStock = showpro[wksID].CurrentStock - reqNum;
                    File.WriteAllText("./" + place + "_inventory.json", JsonConvert.SerializeObject(showpro, Formatting.Indented));
                    List<RetailPro> selectproduct = new List<RetailPro> { (showpro[wksID]) };
                    StreamWriter OwnersInventory = new StreamWriter("ticket.json", true);
                    core showpd = new core();
                    if (selectproduct != null)
                    {

                        bool ifDiscount1 = true;
                        showpd.checkdiscount1 = ifDiscount1;

                    }

                    var AA = JsonConvert.SerializeObject(selectproduct, Formatting.Indented);

                    OwnersInventory.Write(AA);
                    OwnersInventory.Close();
                    Console.Write("purchasses is succeed." + "\n");

                    Console.WriteLine("Do u want keep purchassing?(Y/N)");

                    string p2 = Console.ReadLine();
                    switch (p2)
                    {
                        case "Y":
                        case "y":
                            Console.Clear();
                            displayProducts(place, n);
                            break;
                        case "N":
                        case "n":
                            Console.Clear();
                            retial(place);
                            break;
                        default:
                            Console.WriteLine("wrong option.");
                            break;

                    }
                }
            }
          else
            {
                Console.WriteLine("Stock not enough");
                Console.WriteLine("Do u want keep purchassing?(Y/N)");

                string p1 = Console.ReadLine();
                switch (p1)
                {
                    case "Y":
                    case "y":
                        Console.Clear();
                        displayProducts(place, n);
                        break;
                    case "N":
                    case "n":
                        Console.Clear();
                        retial(place);
                        break;
                    default:
                        Console.WriteLine("wrong option.");
                        break;

                }
            }
          }


       
       

    }


   public class showWorkshop : Menu
    {
       

        public static void displayWorkshops(string place)
        {
            ShowWorkshop(place);
            BookingWorkshop(place);


        }
        static List<Workshop> ShowWorkshop(string place)
        {
            Console.WriteLine("Workshop ID" + "\t" + "StoreName" + "\t" + "Workshop   Date" + "\t" + "Time" + "\t" + "Available Places ");
            Console.WriteLine("===================================================================");
            string workshop = File.ReadAllText("./workshop.json");
            var rerelist = Newtonsoft.Json.JsonConvert.SerializeObject(workshop);
            var showpro = JsonConvert.DeserializeObject<List<Workshop>>(workshop);
            foreach (var wks in showpro)
            {
                if (wks.wkStoreName == place)
                {
                    
                    if (wks.avaPlace != 0)
                    {
                        Console.Write((wks.wkID + "\t" + "\t" + wks.wkName + "\t" + wks.wkStoreName + "\t" + wks.Date + "\t" + wks.Time + "\t" + "\t" + wks.avaPlace + "\n"));
                    }
                    else
                    {
                        Console.Write((wks.wkID + "\t" + "\t" + wks.wkName + "\t" + wks.wkStoreName + "\t" + wks.Date + "\t" + wks.Time + "\t" + "\t" + "Not Available" + "\n"));
                    }
                }
                  
            }
            return showpro;
        }
        public static void BookingWorkshop(string place)
        {
            Console.Write("\n"+"Please enter the workshop ID ( entre  0  to back last menu)" + "\n");

            int selectNum = int.Parse(Console.ReadLine());
            string workshop = File.ReadAllText("./workshop.json");

            if ( selectNum == 0) {

                retial(place);

            }

            var showpro = JsonConvert.DeserializeObject<List<Workshop>>(workshop);
            int wksID = selectNum - 1;
            
            if (showpro[wksID].avaPlace != 0)
        { 
            showpro[wksID].avaPlace = showpro[wksID].avaPlace - 1;
            File.WriteAllText("workshop.json", JsonConvert.SerializeObject(showpro, Formatting.Indented));
            StreamWriter OwnersInventory = new StreamWriter("wkticket.json", true);
            List<Workshop> selectproduct = new List<Workshop> { (showpro[wksID]) };
                // check if booking workshop
                core showwk = new core();
                if (selectproduct != null)
                {

                    bool ifDiscount2 = true;
                    showwk.checkdiscount2 = ifDiscount2;
                   
                }
 
                var AA = JsonConvert.SerializeObject(selectproduct, Formatting.Indented);

            OwnersInventory.Write(AA);
            OwnersInventory.Close();
                
                Console.Write("Ur booking is succeed." + "\n");
            Console.Write("Ur booking reference number is:" + "\n");

                System.Random aa = new Random();
                int refNum = aa.Next(100000, 999999);
                Console.WriteLine(refNum);
                
                showwk.RefeNum = refNum;




               
                if (core.checkDiscount1 == true && core.checkDiscount2 == true)
                {
                 bool ifDiscount = true;
                 showwk.checkdiscount = ifDiscount;
                    Console.Write("And U have 10% discount for product purchases" + "\n");
                }
                else
                {
                    Console.Write("If books both workshop and any product in one shop, u will get 10% discount." + "\n");
                }
               
                Console.WriteLine("Please press any keys to returen to menu.");

                string s3 = Console.ReadLine();
                switch (s3)
                {
                    case "":
                        Console.Clear();
                        retial(place);
                        break;
                    default:
                        Console.Clear();
                        retial(place);
                        break;

                }
            }
             else
                    {
                        Console.Write( "This session is not available right now " + "\n");
                Console.WriteLine("Do u want keep booking?(Y/N)");

                string p1 = Console.ReadLine();
                switch (p1)
                {
                    case "Y":
                    case "y":
                        Console.Clear();
                        displayWorkshops(place);
                        break;
                    case "N":
                    case "n":
                        Console.Clear();
                        retial(place);
                        break;
                    default:
                        Console.WriteLine("wrong option.");
                        break;

                }
            }
          

    }




        public static void printTicket(string place)
        {
            core showwk = new core();
            int totalPrice = 0;
            Console.WriteLine("             Ticket");
            Console.WriteLine("===================================================================");
            Console.WriteLine(" Purchases");
            Console.WriteLine("===================================================================");
            Console.WriteLine("Name" + "\t" + "\t" + "Item" + "\t" + "Price" + "\n");

            string pr = File.ReadAllText("./ticket.json");
           
                string newpr = pr.Replace("][", ",");
                var rerelist = Newtonsoft.Json.JsonConvert.SerializeObject(newpr);
                var showpro = JsonConvert.DeserializeObject<List<RetailPro>>(newpr);

            if (showpro == null)
            {
                Console.Write("No products were been selected.");

            }
            else
            {
                foreach (var prtk in showpro)
                {
                    int prototalPrice = prtk.Request * prtk.Price;
                    Console.Write((prtk.ProductName + "\t" + "\t" + prtk.Request + "\t" + prototalPrice+"\n"));
                    
                    totalPrice += prototalPrice;
                }
                   Console.WriteLine("Total Price is:" +"\t" +totalPrice+"\n");
                
                bool newDiscount = showwk.checkdiscount;
                if (newDiscount == true)
                {
                    Console.WriteLine("U have 10% discount for product purchases" + "\n");
                     double newTotalPrice = totalPrice * 0.9;
                    Console.WriteLine("U need pay:"+ newTotalPrice);
                }
                else
                {
                    Console.WriteLine("sorry no discount" + "\n");
                }
            }
                Console.WriteLine("\n" + "\n");
                Console.WriteLine(" Workshop");
                Console.WriteLine("===================================================================");
                Console.Write("Ur booking reference number is:" + "\n");
            
            int newrefeNum = showwk.RefeNum;
                Console.Write(newrefeNum + "\n");
                Console.WriteLine("===================================================================");
                Console.WriteLine("Workshop ID" + "\t" + "Workshop" + "\t" + "StoreName  Date" + "\t" + "Time" + "\n");
                Console.WriteLine("===================================================================");
                string workshop = File.ReadAllText("./wkticket.json");
                string newwkp = workshop.Replace("][", ",");
                var rerelistwk = Newtonsoft.Json.JsonConvert.SerializeObject(newwkp);
                var showprowk = JsonConvert.DeserializeObject<List<Workshop>>(newwkp);

                if (showprowk==null)
                { Console.WriteLine("no books producets were selected");
                    Console.WriteLine("Please press any keys to returen to menu.");

                    string s3 = Console.ReadLine();
                    switch (s3)
                    {
                        case "":
                            Console.Clear();
                            retial(place);
                            break;
                        default:
                            Console.Clear();
                            retial(place);
                            break;
                    } }
                else {
                    foreach (var wks in showprowk)
                    {
                        Console.Write((wks.wkName + "\t" + wks.wkStoreName + "\t" + wks.Date + "\t" + wks.Time + "\n"));



                    }
                

            }
                //chu ticket.txt

            FileStream fsTick = new FileStream("./ticket.json", FileMode.Create, FileAccess.Write);
            FileStream fsTick1 = new FileStream("./wkticket.json", FileMode.Create, FileAccess.Write);
            Console.ReadKey();
            } 
    }
}


   