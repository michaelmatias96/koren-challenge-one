import java.util.ArrayList; 
import java.util.Scanner;

public class Warehouse{
	
	private ArrayList <Store> storeBranches;

	// method that returns every WareHouse King branch store that sells/has the given product 
	public ArrayList<Store> storeFinder(String productName){
		ArrayList<Store> storesWithProduct = new ArrayList<Store>(); 
		for(Store s: storeBranches){
			if(s.hasProduct(productName)){
				storesWithProduct.add(s); 
			}
		}
		return storesWithProduct; 
	}

	
	public static void main(String[] args) {
		Product apple = new Product("apple", 2.00, 50); 
		Product banana = new Product("banana", 2.00, 50); 
		Product cinnamonRoll = new Product("cinnamon roll", 4.00, 15); 
		Product croissant = new Product("croissant", 3.00, 10); 
		Product proteinShake = new Product("Protein Shake", 6.00, 20);
		
		ArrayList<Product> productList = new ArrayList<Product>(); 
		ArrayList<Product> secondProductList = new ArrayList<Product>(); 
		
		productList.add(apple); productList.add(banana); productList.add(cinnamonRoll); productList.add(croissant);
		secondProductList.add(apple); secondProductList.add(cinnamonRoll); secondProductList.add(proteinShake);
		
		WorkingHours workingHours = new WorkingHours(800, 2200); 
		WorkingHours workingHoursTwo = new WorkingHours(700, 1900); 
		
		Store ramatAvivStore = new Store(workingHours, "Branch 1: Ramat Aviv", productList); 
		Store herzStore = new Store(workingHoursTwo, "Branch 2: Hertiziliyah", secondProductList); 
		Store netanyaStore = new Store(workingHours, "Branch 3: Netanya", productList);

		Transaction transaction = new Transaction(productList, ramatAvivStore);
		Transaction secondTrans = new Transaction(secondProductList, herzStore); 
		ramatAvivStore.executeTransaction(transaction);
		herzStore.executeTransaction(secondTrans);
		netanyaStore.executeTransaction(transaction);
		

		Scanner scanner =new Scanner(System.in);


		System.out.println("View daily profits: enter 1 for Ramat-Aviv store, 2 for Hertziliyah store, 3 for Netanya store");

		int storeForProfit = scanner.nextInt();
		if(storeForProfit == 1) {
			System.out.println(ramatAvivStore.getDailyProfit());
		}
		if(storeForProfit == 2) {
			System.out.println(herzStore.getDailyProfit());
		}
		if(storeForProfit == 3) {
			System.out.println(netanyaStore.getDailyProfit()); 
		}
		
		System.out.println("View operating hours. Enter branch code: ");

		int workingHoursNum = scanner.nextInt();
		if(workingHoursNum == 1) {
			System.out.println(ramatAvivStore.getWorkingHours());
		}
		if(workingHoursNum == 2) {
			System.out.println(herzStore.getWorkingHours()); 
		}
		if(workingHoursNum == 3) {
			System.out.println(netanyaStore.getWorkingHours());
		}   
		
		System.out.println("Check whether a product is in the Ramat Aviv store - enter product name: ");
		
		String checkProduct = scanner.next(); 
		boolean result = ramatAvivStore.hasProduct(checkProduct); 
		if(result) {
			System.out.println("The store has " + checkProduct);
		}
		if(!result) {
			System.out.println("The store does not have: " + checkProduct + "s");
		}
	}
}