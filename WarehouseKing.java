import Java.util.ArrayList; 

public class WarehouseKing{
	
	private ArrayList <Store> StoreBranches;

	public String storeFinder(String productName){
		String desiredStores = "These are the stores that have" + productName + "available: "; 
		for(Store s: StoreBranches){
			if(s.hasProduct(productName)){
				desiredStores += s.getName(); 
				desiredStores += ", "; 
			}
		}
		return desiredStores; 
	}

	public static void main(String[] args) {
		
		StoreBranches = new ArrayList<Store>(); 
	}
}
