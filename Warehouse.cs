using System;
using System.Collections;
using System.Collections.Generic;

namespace StoreManager
{
    public class Warehouse : IEnumerable
    {
        private List<Store> storeBranches = new List<Store>(); 

        // method that returns every WareHouse King branch store that sells/has the given product 
        public List<Store> GetStoresByProduct(Product targetProduct)
        {
            List<Store> storesWithProduct = new List<Store>();
            foreach (Store store in storeBranches)
            {
                if (store.HasProduct(targetProduct))
                {
                    storesWithProduct.Add(store);
                }
            }
            return storesWithProduct;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Store store in storeBranches)
            {
                yield return store; 
            }
        }
  
        public void InitializeValues()
        {
            ProductType apple = new ProductType("apple", 50); 
            Product apple1 = new Product("apple1", 2.00, apple);
            Product apple2 = new Product("apple2", 2.00, apple);

            ProductType cinnamonRoll = new ProductType("cinnamon roll", 10);
            Product cinnamonRoll1 = new Product("cinnamon roll 1", 4.00, cinnamonRoll);
            Product cinnamonRoll2 = new Product("cinnamon roll 2", 4.00, cinnamonRoll);

            ProductType proteinShake = new ProductType("protein shake", 4); 
            Product proteinShake1 = new Product("Protein Shake 1", 6.00, proteinShake);

            List<Product> firstProductList = new List<Product>();
            List<Product> secondProductList = new List<Product>();

            firstProductList.Add(apple1);
            firstProductList.Add(apple2);
            firstProductList.Add(cinnamonRoll1);
            firstProductList.Add(cinnamonRoll2);

            secondProductList.Add(apple1);
            secondProductList.Add(proteinShake1);

            List<ProductType> firstProductTypeList = new List<ProductType>();
            List<ProductType> secondProductTypeList = new List<ProductType>();

            firstProductTypeList.Add(apple);  
            firstProductTypeList.Add(cinnamonRoll);
            secondProductTypeList.Add(apple);
            secondProductTypeList.Add(proteinShake);

            WorkingHours workingHours = new WorkingHours(800, 2200);
            WorkingHours workingHoursTwo = new WorkingHours(700, 1900);

            Store ramatAvivStore = new Store(workingHours, "Branch 1: Ramat Aviv", firstProductTypeList, firstProductList);
            Store herzStore = new Store(workingHoursTwo, "Branch 2: Hertiziliyah", secondProductTypeList, secondProductList);
            Store netanyaStore = new Store(workingHours, "Branch 3: Netanya", secondProductTypeList, firstProductList);

            Transaction transaction = new Transaction(firstProductList);
            Transaction secondTransaction = new Transaction(secondProductList);
            Transaction thirdTransaction = new Transaction(firstProductList);
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
                string storeWorkingHours = ramatAvivStore.GetWorkingHours().toString();
                Console.WriteLine(storeWorkingHours);
            }
            if (desiredStore.Equals("2"))
            {
                string storeWorkingHours = herzStore.GetWorkingHours().toString();
                Console.WriteLine(storeWorkingHours);
            }
            if (desiredStore.Equals("3"))
            {
                string storeWorkingHours = netanyaStore.GetWorkingHours().toString();
                Console.WriteLine(storeWorkingHours);
            }

            Console.WriteLine("Check whether a product is in the Ramat Aviv store - enter product name: ");

            string productName = Console.ReadLine();
            Product productToCheck = new Product(productName, 2.00, apple);
            bool result = ramatAvivStore.HasProduct(productToCheck);
            if (result)
            {
                Console.WriteLine("The store has " + productName + "s");
            }
            if (!result)
            {
                Console.WriteLine("The store does not have: " + productName + "s");
            }
        }
    }
}
