using System;
using System.Collections;
using System.Collections.Generic; 

namespace StoreManager
{
    public class Transaction
    {
        /* Create a list of product objects that represents every product that will be purchased in this transaction.
         * The number of items that are purchased for each type of product is stored in that product's numberToPurchase variable. 
         * For example: if in this transaction I'm buying 3 apples: the Apple object will have its numberToPurchase set to 3. 
         * NOTE: the product objects that are inserted into each transaction's product list are the given store's already-created product objects. 
         */ 

        private List<Product> productsToPurchase = new List<Product>();
        public string transactionDate; 

        // constructor -- input a list of the products to be purchased in this transaction 
        public Transaction(List<Product> inputedProductsToPurchase)
        {
            productsToPurchase = inputedProductsToPurchase;
        }

        public void setTransactionDate()
        {
            DateTime todayDate = new DateTime();
            transactionDate = todayDate.ToString("d");
        }

        // returns the list of products in this transaction 
        public List<Product> GetProductList()
        {
            return productsToPurchase; 
        }

        // returns the total cost of the transaction 
        public double GetTransactionCost()
        {
            double totalCost = 0;
            foreach (Product product in productsToPurchase)
            {
                totalCost += product.GetPrice();
            }
            return totalCost;
        }

        public int GetNumberItems()
        {
            int totalItemsPurchased = 0;
            foreach (Product product in productsToPurchase)
            {
                totalItemsPurchased += product.GetNumberToPurchase();
            }
            return totalItemsPurchased;
        }
    }
}
