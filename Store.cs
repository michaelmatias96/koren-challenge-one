using System;
using System.Collections;
using System.Collections.Generic;

namespace StoreManager
{
    public class Store : IEnumerable
    {
        private string storeName;
        private WorkingHours storeWorkingHours;
        private bool storeIsOpen; 
        private double dailyProfit;
        private int MAX_DAILY_PROFIT = 10000;
        private int productsSold;
        private Dictionary<DateTime, double> everyDailyProfit = new Dictionary<DateTime, double>(); 
        private List<ProductType> availableProductTypes = new List<ProductType>();
        private List<Product> allProductsInStore = new List<Product>();
        private Dictionary<ProductType, int> inventoryCountByProductType = new Dictionary<ProductType, int>(); 
       

        /* constructor -- the store manager does the following:
         * 
         *          - establishes the store's name and working hours (by creating a WorkingHours object)
         *          - creates a 'ProductType' object for every type of product he has at his store 
                    - creates an List of these ProductType objects. The list represents the store's available products. 
                    - creates a list of every single product he has at the store. 
         */
        public Store(WorkingHours storeWorkingHours, string storeName, List<ProductType> availableProductTypes, List<Product> allProductsInStore)
        {
            this.storeWorkingHours = storeWorkingHours;
            this.storeName = storeName;
            this.availableProductTypes = availableProductTypes;
            this.allProductsInStore = allProductsInStore; 
        }


        // returns the name of the store 
        public string GetName()
        {
            return storeName;
        }

        // returns today's total daily profit 
        public double GetDailyProfit()
        {
            return dailyProfit;
        }

        // returns this store's working hours object
        public WorkingHours GetWorkingHours()
        {
            return storeWorkingHours;
        }

        // returns today's date as a DateTime object 
        public DateTime GetDateTime()
        {
            DateTime todayDate = DateTime.Today;
            return todayDate;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Product product in allProductsInStore)
            {
                yield return product; 
            }
        }

        /* method to check if the store should close right now:
         * if the current hour is the designated closing hour or if today's profit has reached or exceeded $10,000
         * returns true if the store should close now. returns false otherwise. 
         */
        public bool shouldCloseStore()
        {
            int currentHour = GetDateTime().Hour; 
            return (currentHour == storeWorkingHours.GetClosingHour() || dailyProfit >= MAX_DAILY_PROFIT);
        }
       
        /* method to close the store (if the closing conditions are met):
         * if so: (1) resets daily profit and products sold to 0, 
         *        (2) adds today's profit to the dictionary of every daily profit with today's date in string format as the key
         */                                           
        public void CloseStore()
        {
            if(shouldCloseStore())
            {
                everyDailyProfit.Add(GetDateTime(), dailyProfit);
                dailyProfit = 0;
                productsSold = 0;
                storeIsOpen = false; 
            }
        }

        // method to open the store, if possible. Updates the store's status to open. 
        public void OpenStore()
        {
            if(!shouldCloseStore())
            {
                storeIsOpen = true; 
            }
        }


        // returns the inputed product 
        public Product GetProduct(Product targetProduct)
        {
            foreach (Product product in allProductsInStore)
            {
                if (product.CompareTo(targetProduct) == 0)
                {
                    return product;
                }
            }
            return allProductsInStore[0];
        }

        // checks if a given product is available in store 
        public bool HasProduct(Product targetProduct)
        {
            foreach (Product product in allProductsInStore)
            {
                if (product.CompareTo(targetProduct) == 0)
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

        // method to check if a given transaction can occur in this store. If not, returns a list of products that aren't available in store. 
        // If all products are available, returns an empty list 
        public List<Product> TransactionCanOccur(Transaction transactionToCheck)
        {
            var missingProducts = new List<Product>(); 
            foreach (Product product in transactionToCheck.GetProductList())
            {
                if (!this.HasProduct(product))
                {
                    missingProducts.Add(product); 
                }
            }
            return missingProducts;
        }


        // method to execute a transaction. A transaction is composed of a list of product objects to purchase. 
        public void ExecuteTransaction(Transaction currentTransaction)
        {
            // if this store is currently open and transaction can occur 
            if (storeIsOpen && (TransactionCanOccur(currentTransaction).Count == 0) )
            {
                // update the store's total daily profit and its tally of how many items were purchased today 
                double transactionCost = currentTransaction.GetTransactionCost();
                this.AddDailyProfit(transactionCost);
                int totalNumberItemsPurchased = currentTransaction.GetNumberItemsPurchased();
                AddSaleCount(totalNumberItemsPurchased);

                // update the inventory count for each product in the transaction
                foreach (Product product in currentTransaction.GetProductList())
                {
                    ProductType currentProductType = product.GetProductType(); 

                    // if there aren't enough items of this product in-stock, re-stock immediately. 
                    if (inventoryCountByProductType[currentProductType] == 0)
                    {
                        inventoryCountByProductType[currentProductType] = 50; 
                    }

                    inventoryCountByProductType[currentProductType] -= 1; 
                }
            }

            // checks if the store should close after this transaction has been executed, and if so closes it. 
            if(shouldCloseStore())
            {
                CloseStore();
            }
        }

        // method to refund a transaction - (1) update each product's inventory list according to how many were returned, 
        // (2) update the dictionary daily profit entry for that date 
        public void ExecuteRefund(Transaction transactionToRefund)
        {
            
            foreach (Product product in transactionToRefund.GetProductList())
            {
                ProductType currentProductType = product.GetProductType();
                inventoryCountByProductType[currentProductType] += 1; 
            }
            everyDailyProfit[transactionToRefund.GetTransactionDate()] -= transactionToRefund.GetTransactionCost(); 
        }
    }
}
