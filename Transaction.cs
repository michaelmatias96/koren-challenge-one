using System;
using System.Collections;
using System.Collections.Generic; 

namespace StoreManager
{
    public class Transaction
    {
        // this is a list of product objects that represents every product that will be purchased in this transaction
        private List<Product> ProductsToPurchase = new List<Product>();

        // the transaction is being executed in this store
        Store currentStore;

        // constructor -- input (1) a list of products to be purchased and (2) the store in which this transaction is occuring 
        public Transaction(List<Product> inputedProductsToPurchase, Store currentStore)
        {
            this.ProductsToPurchase = inputedProductsToPurchase;
            this.currentStore = currentStore;
        }

        // returns the total cost of the transaction 
        public double GetTransactionCost()
        {
            double totalCost = 0;
            foreach (Product product in ProductsToPurchase)
            {
                totalCost += product.GetPrice();
            }
            return totalCost;
        }

        public bool CanOccur()
        {
            foreach (Product product in ProductsToPurchase)
            {
                if (!currentStore.HasProduct(product.GetName()))
                {
                    return false;
                }
            }
            return true;
        }

        // executes the transaction -- if it can occur (the currenStore has every product we want to purchase) 
        public void ExecuteTransaction()
        {
            if (this.CanOccur())
            {

                // first, add the profit made by the store from this transaction 
                double totalTransactionCost = this.GetTransactionCost();
                currentStore.AddDailyProfit(totalTransactionCost);

                // then update the current store's tally of total products sold today
                currentStore.AddSaleCount(ProductsToPurchase.Count);

                // finally , update the store's inventory count for every product purchased
                foreach (Product product in ProductsToPurchase)
                {
                    string productName = product.GetName();
                    // this gives the actual store's product, so we update the inventory count for the store's product 
                    Product theStoreProduct = currentStore.GetProduct(productName);

                    // if the store's inventory of this product is empty, add 50 of it to the inventory 
                    if (theStoreProduct.GetInventoryCount() == 0)
                    {
                        theStoreProduct.AddInventory(50);
                    }

                    // decrease the store's inventory for the product by 1 
                    theStoreProduct.SubtractInventory();
                }
            }
        }
    }
}
