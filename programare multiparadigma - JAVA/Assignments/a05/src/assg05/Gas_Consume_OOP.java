package assg05;

import java.util.Scanner;

class GasConsume {
	private double litersConsumed;
	private double costPerLiter;
	
	public GasConsume(double litersConsumed, double costPerLiter) {
		this.litersConsumed = litersConsumed;
		this.costPerLiter = costPerLiter;
	}

	public double getLitersConsumed() {
		return litersConsumed;
	}

	public double getCostPerLiter() {
		return costPerLiter;
	}
	
	public double moneySpent() {
		return litersConsumed * costPerLiter;
	}
}

public class Gas_Consume_OOP {
	public static void main (String[] args) {
		Scanner input = new Scanner(System.in);
		
		System.out.println("Enter the number of days: ");
		int nbd = input.nextInt();
		
		GasConsume[] gasConsumed = new GasConsume[nbd];
		double totalLits = 0, Money = 0;
		
		for (int i = 0; i < nbd; i++) {
			System.out.println("Liters consumed on day " + (i+1) + " :");
			double liters = input.nextDouble();
			System.out.println("Cost per liter on day " + (i+1) + " :");
			double cost = input.nextDouble();
			
			gasConsumed[i] = new GasConsume(liters, cost);
			
			totalLits += gasConsumed[i].getLitersConsumed();
			Money += gasConsumed[i].moneySpent();
		}
		
		System.out.println("Total liters consumed: " + totalLits);
		System.out.println("Total money spent: " + Money);
		System.out.println("Average of liters consumed: " + totalLits/nbd);
		System.out.println("Average Money Spent per Day: " + Money/nbd);
		
		input.close();
	}
}
