using System;
using System.Collections;
using System.Collections.Generic;

namespace StoreManager
{
    public class Store
    {
        WorkingHours storeWorkingHours;
        private int CLOSING_PROFIT = 10000;
        private List<Product> productList = new List<Product>();
        private double dailyProfit;
        private int productsSold;
        private string storeName;
        private Dictionary<string, int> everyDailyProfit = new Dictionary<string, int>(); 
       

        /* constructor -- the store manager does the following:
         * 
         *          - establish working hours (through WorkingHours object) and store name. 
         *          - creates a 'Product' object for every product he has at his store (see Product class for specifics) 
                    - creates an ArrayList of these products and inputs that list to represent the store's available products 
         */
        public Store(WorkingHours storeWorkingHours, string storeName, List<Product> inputedProductList)
        {
            this.storeWorkingHours = storeWorkingHours;
            this.storeName = storeName;
            productList = inputedProductList;
        }


        // returns the name of the store 
        public string GetName()
        {
            return storeName;
        }

        // get today's profit 
        public double GetDailyProfit()
        {
            return dailyProfit;
        }

        // get this store's working hours object

        public WorkingHours GetWorkingHours()
        {
            return storeWorkingHours;
        }

        // returns today's date in a String format 
        private string GetDate()
        {
            DateTime todayDate = DateTime.Today;
            return todayDate.ToString("d");
        }


        /* allows the store to close if the current hour is the designated closing hour or if today's profit has reached or exceeded $10,000
         * if so: (1) resets daily profit and products sold to 0, 
         *        (2) adds today's profit to the dictionary of every daily profit with today's date as the key
         * returns true if closing conditions are met. returns false otherwise.  
         */
        public bool CloseStore()
        {
            DateTime todayDate = DateTime.Today;
            int hour = todayDate.Hour; 
            if (hour == storeWorkingHours.GetClosingHour() || dailyProfit >= CLOSING_PROFIT)
            {
                int todayProfit = (int)dailyProfit;
                everyDailyProfit.Add(GetDate(), todayProfit);
                dailyProfit = 0;
                productsSold = 0;
                return true;
            }
            return false;
        }

        // method to check if the store is currently open 
        public bool IsOpen()
        {
            return !this.CloseStore();
        }


        // returns the Product object with the given name 
        public Product GetProduct(string productName)
        {
            foreach (Product p in productList)
            {
                if (productName.Equals(p.GetName()))
                {
                    return p;
                }
            }
            return productList[0];
        }

        // checks if a given product is available in store 
        public bool HasProduct(string productName)
        {
            foreach (Product p in productList)
            {
                if (productName.Equals(p.GetName()))
                {
                    return true;
                }
            }
            return false;
        }

        // method to add daily profit after a sale 
        public void AddDailyProfit(double n)
        {
            dailyProfit += n;
        }

        // updates the tally of how many products were sold today by salesToAdd
        public void AddSaleCount(int salesToAdd)
        {
            productsSold += salesToAdd;
        }

        // method to execute a transaction 
        public void ExecuteTransaction(Transaction currentTransaction)
        {

            if (IsOpen())
            {
                // if this store is currently open

                currentTransaction.ExecuteTransaction();
                // executes the given transaction -- see Transaction class for details 

                if (this.CloseStore())
                {
                    int todayProfit = (int)dailyProfit;
                    everyDailyProfit.Add(GetDate(), todayProfit);
                    dailyProfit = 0;
                    productsSold = 0;
                }
                // closes the store if, after the executed transaction, the daily profit has exceeded $10,000 or the closing hour has been reached 
                // inserts today's profits to the everyDailyProfit map with today's date as the key 
                // resets the daily profit and products sold to 0. 
            }
        }
    }
}