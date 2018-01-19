import java.util.ArrayList; 

public class Transaction {
	
	// this is a list of product objects that represents every product that will be purchased in this transaction
	private ArrayList<Product> productsToPurchase = new ArrayList<Product>(); 
	
	// the transaction is being executed in this store
	Store currentStore; 
	
	// constructor -- input (1) a list of products to be purchased and (2) the store in which this transaction is occuring 
	public Transaction(ArrayList<Product> productsToPurchase, Store currentStore) {
		this.productsToPurchase = productsToPurchase; 
		this.currentStore = currentStore; 
	}
	
	// returns the total cost of the transaction 
	public double getTransactionCost() {
		double totalCost = 0; 
		for(Product product: productsToPurchase) {
			totalCost += product.getPrice(); 
		}
		return totalCost; 
	}
	
	public boolean canOccur() {
		for(Product product: productsToPurchase) {
			if(!currentStore.hasProduct(product.getName())) {
				return false; 
			}
		}
		return true; 
	}
	
	// executes the transaction -- if it can occur (the currenStore has every product we want to purchase) 
	public void executeTransaction() {
		if(this.canOccur()) {
			
			// first, add the profit made by the store from this transaction 
			double totalTransactionCost = this.getTransactionCost(); 
			currentStore.addDailyProfit(totalTransactionCost);
			
			// then update the current store's tally of total products sold today
			currentStore.addSaleCount(productsToPurchase.size());
			
			// finally , update the store's inventory count for every product purchased
			for(Product product: productsToPurchase) {
				String productName = product.getName(); 
				// this gives the actual store's product, so we update the inventory count for the store's product 
				Product theStoreProduct = currentStore.getProduct(productName); 
				
				// if the store's inventory of this product is empty, add 50 of it to the inventory 
				if(theStoreProduct.getInventoryCount() == 0) {
					theStoreProduct.addInventory(50);
				}
				
				// decrease the store's inventory for the product by 1 
				theStoreProduct.subtractInventory();
			}
		}	
	}
	
}
