package assg05;

import java.util.Scanner;

class ScreenTime {
	private int[] screenMin;
	
	public ScreenTime(int nbd) {
		screenMin = new int[nbd];
	}
	
	public void insertScreentTIme(Scanner input) {
		for (int i=0; i<screenMin.length; i++) {
			System.out.print("Enter minutes spent on screen for day " + (i+1) + " : ");
			screenMin[i] = input.nextInt();
		}
	}
	
	public void findMinMax() {
		int maxMin = screenMin[0];
		int minMin = screenMin[0];
		int maxDay = 1, minDay = 1;

		for (int i=1; i<screenMin.length; i++) {
			if(screenMin[i] > minMin) {
				maxMin = screenMin[i];
				maxDay = i+1;
			}
			
			if(screenMin[i] < minMin) {
				minMin = screenMin[i];
				minDay = i+1;
			}
		}
		
		System.out.println("Largest screen time: " + maxMin + " on day " + maxDay);
		System.out.println("Samllest screen time: " + minMin + " on day " + minDay);
		
	}
}

public class ScreenTime_OOP {

	public static void main(String[] args ) {
		Scanner input = new Scanner(System.in);
		int nbd = 21;
		ScreenTime st = new ScreenTime(nbd);
		st.insertScreentTIme(input);
		st.findMinMax();
		input.close();
	}
}
