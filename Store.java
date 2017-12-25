import Java.util.ArrayList;
import Java.util.Date;
import Java.util.Calendar; 
import Java.util.map;
import Java.util.LinkedHashMap; 

public class Store{

	private int openingHour; 
	private int closingHour;
	private ArrayList<Product>  productList = new ArrayList<Product>();  
	private double dailyProfit; 
	private int productsSold;
	private String storeName; 
	private String lastClose = "";
	private Map<Integer, String> everyDailyProfit = new LinkedHashmap<Integer, String>(); 
	
	// constructor -- establish opening hour, closing hour, and store name
	public Store(int h, int c, String s){
		openingHour = h;  
		closingHour = c;
		storeName = s; 
	}

	/*
	The store manager does the following (through the addProduct method):
		creates a 'Product' object for every product he has at his store (see Product class for specifics) 
		adds each Product object to the store's list
		
	*/
	public void addProduct(Product p){
		productList.add(p); 
	}
	
	// returns the name of the store 
	public String getName(){
		return storeName; 
	}

	// closes the store if the current hour is the designated closing hour
	// resets daily profit and products sold to 0. Adds today's profit to the list of every daily profit 
	public void closeStore(){
		Calendar now = Calendar.getInstance();
		int hour = now.get(Calendar.HOUR_OF_DAY);
		if(hour == closingHour){
			lastClose = getDate();
			Integer todayProfit = new Integer(dailyProfit); 
			everyDailyProfit.put(todayProfit, getDate()); 
			dailyProfit = 0; 
			productsSold = 0;
		}
	}
		
	// returns the Product object with the given name 
	public Product getProduct(String productName){
		for(Product p: productList){
			if(productName.equals(p.getName()) ){
				return p;
			}
		}
	}

	// checks if a given product is available in store 
	public boolean hasProduct(String productName){
		for(Product p: productList){
			if(productName.equals(p.getName()) ){
				return true; 
			}
		}
		return false; 
	}

	// method to add daily profit after a sale 
	public void addDailyProfit(double n){
		dailyProfit += n; 
	}
	
	// updates the tally of how many products were sold today 
	public void addSaleCount(){
		productsSold++ ; 
	}

	// method to purchase a certain product
	public void purchaseProduct(String productName){

		if(hasProduct(productName) && !getDate().equals(lastClose)){
			// if this store has the product we want and it's currently open 

			Product theProduct = getProduct(productName); 
			// we now have the product which we are purchasing 

			if(theProduct.getInventoryCount() == 0){
				theProduct.addInventory(50); 
			}
			// check if the store has run out of the product, and if so adds 50 of it
			
			theProduct.subtractInventory();

			double priceToAdd = theProduct.getPrice(); 
			addDailyProfit(priceToAdd); 
			// updates the daily profit made in this transaction 

			addSaleCount(); 
			// updates how many products were sold today 
			
			if (dailyProfit >= 10000){
				lastClose = getDate();
				Integer todayProfit = new Integer(dailyProfit); 
				everyDailyProfit.put(todayProfit, getDate()); 
				dailyProfit = 0; 
				productsSold = 0; 
			}
			// closes the store if, after the executed transaction, the daily profit has exceeded $10,000
			// Resets the daily profit and products sold to 0. 
		}
	}
	
	// get today's profit 
	public double getDailyProfit(){
		return dailyProfit;
	}
		
	// returns today's date in a String format 
	private String getDate(){
		DateFormat format = new DateFormat("yyyy/MM/dd");
		return format.format(new Date());
	}
}
