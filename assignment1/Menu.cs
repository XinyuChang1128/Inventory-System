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

    public  class core
    {
        public static int refeNum;
   
        public static bool checkDiscount;
        public static bool checkDiscount1 = false;
        public static bool checkDiscount2 = false;

        public int RefeNum
        {
            get { return core.refeNum; }
            set { core.refeNum = value; }
        }
        public bool checkdiscount
        {
            get { return core.checkDiscount; }
            set { core.checkDiscount = value; }
        }

        public bool checkdiscount1
        {
            get { return core.checkDiscount1; }
            set { core.checkDiscount1 = value; }
        }

        public bool checkdiscount2
        {
            get { return core.checkDiscount2; }
            set { core.checkDiscount2 = value; }
        }
    }
    public  class Menu
    {
        
        static void Main(string[] args)
        {

            mainMenu();
        }
        public static void mainMenu()
        {

            begin:
            Console.Clear();
            Console.WriteLine("Welcome to Marvellous Magic");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Owner");
            Console.WriteLine("2. Franchise Owner");
            Console.WriteLine("3. Customer");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Enter an option(from 1-4):");

            string i = Console.ReadLine();
            switch (i)
            {
                case "1":
                    Console.Clear();
                    ownermenu();
                    break;
                case "2":
                    Console.Clear();
                    ChoseStoreF();
                    break;
                case "3":
                    Console.Clear();
                    ChoseStore();
                    break;
                case "4":
                    Console.Clear();
                    System.Environment.Exit(-1);
                    break;
                default:
                    Console.WriteLine("wrong option.");
                    Console.Clear();
                    break;
            }
            goto begin;
        }

        public static void ownermenu()
        {

            Console.WriteLine("Welcome to Marvellous Magic (Owner)");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Display All Stock Requests");
            Console.WriteLine("2. Display Stock Requests (True/False)");
            Console.WriteLine("3. Display All Product Lines");
            Console.WriteLine("4. Return to Main Menu");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter an option(from 1-5):");
            string i1 = Console.ReadLine();
            switch (i1)
            {
                case "1":
                    Console.Clear();
                    onwer.AllStock();
                    break;
                case "2":
                    Console.Clear();
                    onwer.StockRequests();
                    break;
                case "3":
                    Console.Clear();
                    onwer.AllProductLines();
                    break;
                case "4":
                    mainMenu();
                    break;
                case "5":
                    System.Environment.Exit(-1);
                    break;
                default:
                    Console.WriteLine("wrong option.");
                    break;
            }
        }
        public static void Franchise(string place)
        {
                    Console.WriteLine("Welcome to Marvellous Magic (Franchise Holder )"+place);
                    Console.WriteLine("==========================");
                    Console.WriteLine("1. Display Inventory");
                    Console.WriteLine("2. Display Inventory (Threshold)");
                    Console.WriteLine("3. Add New Inventory Item");
                    Console.WriteLine("4. Return to Main Menu");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("Enter an option(from 1-5):");
                    string f1 = Console.ReadLine();
                    switch (f1)
                    {
                        case "1":
                            franchise.DisplayInventory(place);
                            //restock();
                            break;
                        case "2":
                             franchise.DisplayLow(place);
                             break;
                        case "3":
                    
                              franchise.Display(place);
                              break;
                        case "4":
                            mainMenu();
                            break;
                        case "5":
                            System.Environment.Exit(-1);
                            break;
                        default:
                            Console.WriteLine("wrong option.");
                            break;
                    }
                  
        }

                    public static void retial(string place)
        {

            Console.WriteLine("Welcome to Marvellous Magic (Retail - Olinda)");
            Console.WriteLine("==========================");
            Console.WriteLine("1.Display Products");
            Console.WriteLine("2. Display Workshops");
            Console.WriteLine("3. Return to Main Menu");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter an option(from 1-4):");
            string i3 = Console.ReadLine();
            switch (i3)
            {
                case "1":
                    Console.Clear();
                    Retial.displayProducts(place,5);// dian ming de json 
                    break;
                case "2":
                    Console.Clear();
                    showWorkshop.displayWorkshops(place);
                    break;
                case "3":
                    mainMenu();
                    break;
                case "4":
                    System.Environment.Exit(-1);
                    break;
                default:
                    Console.WriteLine("wrong option.");
                    break;
            }
        }


        public static void ChoseStore()
        {

            Console.WriteLine("Welcome to Marvellous Magic (Please Chose the store)");
            Console.WriteLine("==========================");
            Console.WriteLine("1. CBD");
            Console.WriteLine("2. East");
            Console.WriteLine("3. South");
            Console.WriteLine("4. West");
            Console.WriteLine("5. North");
            Console.WriteLine("6. Return to Main Menu");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Enter an option(from 1-7):");
            string s1 = Console.ReadLine();
            switch (s1)
            {
                case "1":
                    Console.Clear();
                    retial("CBD");
                   
                    break;
                case "2":

                    Console.Clear();
                    retial("East");
                    
                    break;
                case "3":
                    Console.Clear();
                    retial("South");
                   
                    break;
                case "4":
                    Console.Clear();
                    retial("West");
                 
                    break;
                case "5":
                    Console.Clear();
                    retial("North");
                   
                    break;
                case "6":
                    Console.Clear();
                    mainMenu();
                    break;
                case "7":
                    Console.Clear();
                    System.Environment.Exit(-1);
                    break;
                default:
                    Console.WriteLine("wrong option.");

                    break;
            }
        }

        public static void ChoseStoreF()
        {

            Console.WriteLine("Welcome to Marvellous Magic (Please Chose the store)");
            Console.WriteLine("==========================");
            Console.WriteLine("1. CBD");
            Console.WriteLine("2. East");
            Console.WriteLine("3. South");
            Console.WriteLine("4. West");
            Console.WriteLine("5. North");
            Console.WriteLine("6. Return to Main Menu");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Enter an option(from 1-7):");
            string s1 = Console.ReadLine();
            switch (s1)
            {
                case "1":
                    Console.Clear();
                    
                    Franchise("CBD");
                    break;
                case "2":

                    Console.Clear();
                    
                    Franchise("East");
                    break;
                case "3":
                    Console.Clear();
                    
                    Franchise("South");
                    break;
                case "4":
                    Console.Clear();
                    
                    Franchise("West");
                    break;
                case "5":
                    Console.Clear();
                    
                    Franchise("North");
                    break;
                case "6":
                    Console.Clear();
                    mainMenu();
                    break;
                case "7":
                    Console.Clear();
                    System.Environment.Exit(-1);
                    break;
                default:
                    Console.WriteLine("wrong option.");

                    break;
            }
        }

    }
}