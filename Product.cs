using System;
namespace StoreManager
{
    public class Product : IComparable<Product>
    {
        private ProductType productType; 
        private string productName;
        private double productPrice;
         

        /*
        constructor -- the store manager inputs the following for every product type:
             the name of the product
             the price of 1 product 
             how many instances of that type of product there are initially at his store 
        */

        public Product(string productName, double productPrice, ProductType productType)
        {
            this.productName = productName;
            this.productPrice = productPrice;
            this.productType = productType; 
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

        // returns the type of this product 
        public ProductType GetProductType()
        {
            return productType; 
        }

  
        public int CompareTo(Product otherProduct)
        {
            if( (this.GetName() == otherProduct.GetName()) && (this.GetPrice() == otherProduct.GetPrice()) )
            {
                return 0; 
            }
            else
            {
                return -1; 
            }
        }
    }
}
