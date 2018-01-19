using System;
using System.Collections;
using System.Collections.Generic;

namespace StoreManager
{
    public class Warehouse
    {
        private List<Store> storeBranches = new List<Store>(); 

        // method that returns every WareHouse King branch store that sells/has the given product 
        public List<Store> StoreFinder(string productName)
        {
            List<Store> storesWithProduct = new List<Store>();
            foreach (Store store in storeBranches)
            {
                if (store.HasProduct(productName))
                {
                    storesWithProduct.Add(store);
                }
            }
            return storesWithProduct;
        }


        public static void Main(string[] args)
        {
            Product apple = new Product("apple", 2.00, 50);
            Product banana = new Product("banana", 2.00, 50);
            Product cinnamonRoll = new Product("cinnamon roll", 4.00, 15);
            Product croissant = new Product("croissant", 3.00, 10);
            Product proteinShake = new Product("Protein Shake", 6.00, 20);

            List<Product> firstProductList = new List<Product>();
            List<Product> secondProductList = new List<Product>();

            firstProductList.Add(apple); 
            firstProductList.Add(banana); 
            firstProductList.Add(cinnamonRoll); 
            firstProductList.Add(croissant);
            secondProductList.Add(apple); 
            secondProductList.Add(cinnamonRoll); 
            secondProductList.Add(proteinShake);

            WorkingHours workingHours = new WorkingHours(800, 2200);
            WorkingHours workingHoursTwo = new WorkingHours(700, 1900);

            Store ramatAvivStore = new Store(workingHours, "Branch 1: Ramat Aviv", firstProductList);
            Store herzStore = new Store(workingHoursTwo, "Branch 2: Hertiziliyah", secondProductList);
            Store netanyaStore = new Store(workingHours, "Branch 3: Netanya", firstProductList);

            Transaction transaction = new Transaction(firstProductList, ramatAvivStore);
            Transaction secondTransaction = new Transaction(secondProductList, herzStore);
            Transaction thirdTransaction = new Transaction(firstProductList, netanyaStore); 
            ramatAvivStore.ExecuteTransaction(transaction);
            herzStore.ExecuteTransaction(secondTransaction);
            netanyaStore.ExecuteTransaction(thirdTransaction);



            Console.WriteLine("View daily profits: enter 1 for Ramat-Aviv store, 2 for Hertziliyah store, 3 for Netanya store");

            string storeForProfit = Console.ReadLine(); 

            if (storeForProfit.Equals("1"))
            {
                Console.WriteLine(ramatAvivStore.GetDailyProfit());
            }
            if (storeForProfit.Equals("2"))
            {
                Console.WriteLine(herzStore.GetDailyProfit());
            }
            if (storeForProfit.Equals("3"))
            {
                Console.WriteLine(netanyaStore.GetDailyProfit());
            }

            Console.WriteLine("View operating hours. Enter branch code: ");

            string desiredStore = Console.ReadLine(); 

            if (desiredStore.Equals("1"))
            {
                string storeWorkingHours = ramatAvivStore.GetWorkingHours().GetStringWorkingHours(); 
                Console.WriteLine(storeWorkingHours);
            }
            if (desiredStore.Equals("2"))
            {
                string storeWorkingHours = herzStore.GetWorkingHours().GetStringWorkingHours();
                Console.WriteLine(storeWorkingHours);
            }
                if (desiredStore.Equals("3"))
            {
                string storeWorkingHours = netanyaStore.GetWorkingHours().GetStringWorkingHours();
                Console.WriteLine(storeWorkingHours);
            }

            Console.WriteLine("Check whether a product is in the Ramat Aviv store - enter product name: ");

            string checkProduct = Console.ReadLine();
            bool result = ramatAvivStore.HasProduct(checkProduct);
            if (result)
            {
                Console.WriteLine("The store has " + checkProduct +"s");
            }
            if (!result)
            {
                Console.WriteLine("The store does not have: " + checkProduct + "s");
            }
        }
    }
}
