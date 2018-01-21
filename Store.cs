using System;
using System.Collections;
using System.Collections.Generic;

namespace StoreManager
{
    public class Store
    {
        private WorkingHours storeWorkingHours;
        private bool storeIsOpen; 
        private int CLOSING_PROFIT = 10000;
        private List<Product> productList = new List<Product>();
        private double dailyProfit;
        private int productsSold;
        private string storeName;
        private Dictionary<string, int> everyDailyProfit = new Dictionary<string, int>(); 
       

        /* constructor -- the store manager does the following:
         * 
         *          - establishes the store's name and working hours (by creating a WorkingHours object)
         *          - creates a 'Product' object for every type of product he has at his store (see Product class for specifics) 
                    - creates an List of these product objects. The list represents the store's available products 
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

        // returns today's date in a string format 
        public string GetStringDate()
        {
            DateTime todayDate = DateTime.Today;
            return todayDate.ToString("d");
        }


        /* method to check if the store should close right now:
         * if the current hour is the designated closing hour or if today's profit has reached or exceeded $10,000
         * returns true if the store should close now. returns false otherwise. 
         */
        public bool shouldCloseStore()
        {
            DateTime todayDate = DateTime.Today;
            int currentHour = todayDate.Hour;
            return (currentHour == storeWorkingHours.GetClosingHour() || dailyProfit >= CLOSING_PROFIT);
        }
       
        /* method to close the store (if the closing conditions are met):
         * if so: (1) resets daily profit and products sold to 0, 
         *        (2) adds today's profit to the dictionary of every daily profit with today's date in string format as the key
         */                                           
        public void CloseStore()
        {
            if(shouldCloseStore())
            {
                int todayProfit = (int)dailyProfit;
                everyDailyProfit.Add(GetStringDate(), todayProfit);
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
            foreach (Product product in productList)
            {
                if (targetProduct.GetName().Equals(product.GetName()))
                {
                    return product;
                }
            }
            return productList[0];
        }

        // checks if a given product is available in store 
        public bool HasProduct(Product targetProduct)
        {
            foreach (Product product in productList)
            {
                if (targetProduct.GetName().Equals(product.GetName()))
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

        // method to check if a given transaction can occur in this store. Returns a list of products that aren't available in store. 
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
                AddDailyProfit(transactionCost);
                int totalNumberItemsPurchased = currentTransaction.GetNumberItems();
                AddSaleCount(totalNumberItemsPurchased);

                // update the inventory count for each product in the transaction
                foreach (Product product in currentTransaction.GetProductList())
                {
                    // how many instances of this product are being purchased. for example, if I buy 3 apples in this transaction, numberItems = 3 
                    int numberItems = product.GetNumberToPurchase();

                    // if there aren't enough items of this product in-stock, re-stock immediately. 
                    if (product.GetInventoryCount() < numberItems)
                    {
                        product.AddInventory(numberItems);
                    }

                    product.SubtractInventory(numberItems);
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
            string transactionDate = transactionToRefund.transactionDate; 
            foreach (Product product in transactionToRefund.GetProductList())
            {
                product.AddInventory(product.GetNumberToPurchase());
            }
            everyDailyProfit[transactionDate] -= (int) transactionToRefund.GetTransactionCost(); 
        }
    }
}
