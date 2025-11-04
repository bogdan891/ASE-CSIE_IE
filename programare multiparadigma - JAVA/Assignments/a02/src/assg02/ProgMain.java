package assg02;

public class ProgMain {

	public static void main(String[] args) {
		int num = 10;
		
		System.out.print("     ");
		
		for (int i = 0; i < num; i++) {
			System.out.printf("%4d", i+1);
		}
		
		System.out.println();
		System.out.println("______________________________________________");
		
		for (int i = 0; i < num; i++) {
			System.out.printf("%2d | ", i+1);
			for (int j = 0; j < num; j++) {
				System.out.printf("%4d", (i+1)*(j+1));
			}
			System.out.println();
		}
	}

}
