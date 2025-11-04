package assg05;

import java.util.Scanner;

public class ScreenTime_non_OOP {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int nbd = 21;
		int[] screenMin = new int[nbd];
		
		for (int i=0; i<nbd; i++) {
			System.out.print("Enter minutes spent on screen for day " + (i+1) + " : ");
			screenMin[i] = input.nextInt();
		}
		
		int maxMin = screenMin[0];
		int minMin = screenMin[0];
		int maxDay = 1, minDay = 1;

		for (int i=1; i<nbd; i++) {
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
		
		input.close();
	}

}
