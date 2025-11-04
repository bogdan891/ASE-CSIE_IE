package assg05;

import java.util.Scanner;

public class Gas_Consume_Non_OOP {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		System.out.println("Enter th enumber of days: ");
		int nbd = input.nextInt();
		
		double[] liters = new double[nbd];
		double[] cost = new double[nbd];
		
		double totalLits = 0, Money = 0;
		
		for (int i = 0; i < nbd; i++) {
			System.out.println("Liters consumed on day " + (i+1) + " :");
			liters[i] = input.nextDouble();
			System.out.println("Cost per liter on day " + (i+1) + " :");
			cost[i] = input.nextDouble();
			
			totalLits += liters[i];
			Money += liters[i] * cost[i];
		}
		
		System.out.println("Total liters consumed: " + totalLits);
		System.out.println("Total money spent: " + Money);
		System.out.println("Average of liters consumed: " + totalLits/nbd);
		System.out.println("Average Money Spent per Day: " + Money/nbd);
		
		input.close();

	}

}
