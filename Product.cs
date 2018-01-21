using System;
namespace StoreManager
{
    public class Product
    {
        private string productName;
        private double productPrice;
        private int inventoryCount;
        private int numberToPurchase; 

        /*
        constructor -- the store manager inputs the following for every product type:
             the name of the product
             the price of 1 product 
             how many instances of that type of product there are initially at his store 
        */

        public Product(string productName, double productPrice, int inventoryCount)
        {
            this.productName = productName;
            this.productPrice = productPrice;
            this.inventoryCount = inventoryCount;
        }

        // returns the name of the product 
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

        // for when this product is purchased - the inventory decreases by how many items of this product were purchased
        public void SubtractInventory(int numberItemsBought)
        {
            inventoryCount -= numberItemsBought; 
        }

        public void SetNumberToPurchase(int numberToPurchase)
        {
            this.numberToPurchase = numberToPurchase; 
        }

        public int GetNumberToPurchase()
        {
            return numberToPurchase; 
        }
    }
}
