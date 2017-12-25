public class Product{

	public String name; 
	public double price; 
	public int inventoryCount; 
	
	/*
	constructor -- the store manager inputs the following for every product type:
		 the name
		 the price
		 how many instances of that type of product there are initially at his store 

	*/ 

	public Product(String n, double p, int i){
		name = n; 
		price = p; 
		inventoryCount = i; 
	}

	// returns name of the product 
	public String getName(){
		return name;
	}

	// returns the price of the product 
	public double getPrice(){
		return price; 
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
