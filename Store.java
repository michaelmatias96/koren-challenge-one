import java.util.ArrayList;
import java.util.Date;
import java.util.Calendar; 
import java.text.SimpleDateFormat; 
import java.util.Map;
import java.util.LinkedHashMap; 

public class Store{

	WorkingHours storeWorkingHours; 
	private int CLOSING_PROFIT = 10000; 
	private ArrayList<Product>  productList = new ArrayList<Product>(); 
	private double dailyProfit; 
	private int productsSold;
	private String storeName; 
	private Map<Integer, String> everyDailyProfit = new LinkedHashMap<Integer, String>(); 
	
	/* constructor -- the store manager does the following:
	 * 
	 *  	    - establish working hours (through WorkingHours object) and store name. 
	 *  	    - creates a 'Product' object for every product he has at his store (see Product class for specifics) 
		    - creates an ArrayList of these products and inputs that list to represent the store's available products 
	 */
	public Store(WorkingHours storeWorkingHours, String storeName, ArrayList<Product> inputedProductList){
		this.storeWorkingHours = storeWorkingHours; 
		this.storeName = storeName; 
		productList = inputedProductList; 
	}

	
	// returns the name of the store 
	public String getName(){
		return storeName; 
	}
	
	// get today's profit 
	public double getDailyProfit(){
		return dailyProfit;
	}
	
	// get this store's working hours object
	
	public WorkingHours getWorkingHours() {
		return storeWorkingHours; 
	}
	
	// returns today's date in a String format 
	private String getDate(){
		SimpleDateFormat format = new SimpleDateFormat("yyyy/MM/dd");
		return format.format(new Date());
	}

	
	/* allows the store to close if the current hour is the designated closing hour or if today's profit has reached or exceeded $10,000
	 * if so: (1) sets the lastClosed variable to today, (2) resets daily profit and products sold to 0, 
	 *        (3) adds today's profit to the map of every daily profit with today's date as the key
	 * returns true if closing conditions are met. returns false otherwise.  
	 */
	public boolean closeStore(){
		Calendar now = Calendar.getInstance();
		int hour = now.get(Calendar.HOUR_OF_DAY);
		if(hour == storeWorkingHours.getClosingHour()|| dailyProfit >= CLOSING_PROFIT){
			Integer todayProfit =  (int) dailyProfit; 
			everyDailyProfit.put(todayProfit, getDate()); 
			dailyProfit = 0; 
			productsSold = 0;
			return true; 
		}
		return false; 
	}
	
	// method to check if the store is currently open 
	public boolean isOpen() {
		return !this.closeStore(); 
	}
	
	
	// returns the Product object with the given name 
	public Product getProduct(String productName){
		for(Product p: productList){
			if(productName.equals(p.getName()) ){
				return p;
			}
		}
		return productList.get(0);
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
	
	// updates the tally of how many products were sold today by salesToAdd
	public void addSaleCount(int salesToAdd){
		productsSold+= salesToAdd ; 
	}

	// method to execute a transaction 
	public void executeTransaction(Transaction currentTransaction){

		if(isOpen()){
			// if this store is currently open
			
			currentTransaction.executeTransaction();
			// executes the given transaction -- see Transaction class for details 
			
			if (this.closeStore()){
				Integer todayProfit = (int) dailyProfit; 
				everyDailyProfit.put(todayProfit, getDate()); 
				dailyProfit = 0; 
				productsSold = 0; 
			}
			// closes the store if, after the executed transaction, the daily profit has exceeded $10,000 or the closing hour has been reached 
			// inserts today's profits to the everyDailyProfit map with today's date as the key 
			// resets the daily profit and products sold to 0. 
		}
	}	
}
