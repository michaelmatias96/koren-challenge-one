using System;
namespace StoreManager
{
    public class Product
    {
        private string productName;
        private double productPrice;
        private int inventoryCount;

        /*
        constructor -- the store manager inputs the following for every product type:
             the name
             the price
             how many instances of that type of product there are initially at his store 
        */

        public Product(string productName, double productPrice, int inventoryCount)
        {
            this.productName = productName;
            this.productPrice = productPrice;
            this.inventoryCount = inventoryCount;
        }

        // returns name of the product 
        public string GetName()
        {
            return productName;
        }

        // returns the price of the product 
        public double GetPrice()
        {
            return productPrice;
        }

        // returns the inventory count 
        public int GetInventoryCount()
        {
            return inventoryCount;
        }

        // for when the store runs out, and more must be added 
        public void AddInventory(int n)
        {
            inventoryCount += n;
        }

        // for when this product is purchased, and the inventory decreases by 1 
        public void SubtractInventory()
        {
            inventoryCount -= 1;
        }

    }
}
