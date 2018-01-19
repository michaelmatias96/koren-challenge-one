
public class WorkingHours {
	private int openingHour; 
	private int closingHour; 
	
	public WorkingHours(int openingHour, int closingHour) {
		this.openingHour = openingHour; 
		this.closingHour = closingHour; 
	}
	
	public int getOpeningHour() {
		return openingHour; 
	}
	
	public int getClosingHour() {
		return closingHour; 
	}
	
	public String toString() {
		return "Opening hour: " + openingHour + ". Closing Hour: " + closingHour; 
	}
}
