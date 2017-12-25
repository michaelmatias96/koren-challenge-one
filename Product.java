public class Product{

	private String productName; 
	private double productPrice; 
	private int inventoryCount; 
	
	/*
	constructor -- the store manager inputs the following for every product type:
		 the name
		 the price
		 how many instances of that type of product there are initially at his store 
	*/ 

	public Product(String productName, double productPrice, int inventoryCount){
		this.productName = productName; 
		this.productPrice = productPrice; 
		this.inventoryCount = inventoryCount; 
	}

	// returns name of the product 
	public String getName(){
		return productName;
	}

	// returns the price of the product 
	public double getPrice(){
		return productPrice; 
	}

	// returns the inventory count 
	public int getInventoryCount(){
		return inventoryCount;
	}

	// for when the store runs out, and more must be added 
	public void addInventory(int n){
		inventoryCount += n; 
	}

	// for when this product is purchased, and the inventory decreases by 1 
	public void subtractInventory(){
		inventoryCount -= 1; 
	}
}