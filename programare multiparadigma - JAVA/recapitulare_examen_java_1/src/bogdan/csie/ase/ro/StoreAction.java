package bogdan.csie.ase.ro;

public interface StoreAction {
	public static void openStore() {
		System.out.println("Welcome! We are openned!");
	}
	
	public static void closeStore() {
		System.out.println("Sorry! We are closed!");
	}
	
	public float calculatePrice();

	int compareTo(ClothesStore o);
}
