using System;
namespace StoreManager
{
    public class ProductType
    {
        private string productTypeName;
        private int inventoryCount; 

        public ProductType(string productTypeName, int inventoryCount)
        {
            this.productTypeName = productTypeName;
            this.inventoryCount = inventoryCount; 
        }

        // returns the name of this type of product (i.e. -- apple) 
        public string GetProductTypeName()
        {
            return productTypeName; 
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


    }
}
