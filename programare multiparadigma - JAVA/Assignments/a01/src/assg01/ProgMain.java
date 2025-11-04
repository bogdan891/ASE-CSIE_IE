package assg01;

import java.util.Scanner;

public class ProgMain {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		System.out.println("Enter your filing status: ");
		System.out.println("1-Single; 2-MArried Filing Jointly or Qualifying Widow(er);");
		System.out.println("3-Married Filing Separately; 4-Head of Household;");
		
		int status = in.nextInt();
		
		System.out.println("Enter your income: ");
		double income = in.nextDouble();
		
		double tax = Calculator(status, income);
		System.out.printf("The tax is: $%.2f\n", tax);
	}

	public static double Calculator(int status, double income) {
		double tax = 0;
		switch(status) {
		case 1:
			if (income <= 8350)
				tax = income * 0.10;
			else if (income <= 33950)
				tax = 8350 * 0.10 + (income - 8350) * 0.15;
			else if (income <= 82250)
				tax = 8350 * 0.10 + (33950 - 8350) * 0.15 + 
				(income - 33950) * 0.25;
			else if (income <= 171550)
				tax = 8350 * 0.10 + 33950 * 0.15 + 
				(82250 - 33950) * 0.25 + (income - 82250) * 0.28;
			else if (income <= 372950)
				tax = 8350 * 0.10 + 33950 * 0.15 + 
				(82250 - 33950) * 0.25 + (171550 - 82250) * 0.28
				+ (income - 171550) * 0.33;
			else
				tax = 8350 * 0.10 + 33950 * 0.15 + 
				(82250 - 33950) * 0.25 + (171550 - 82250) * 0.28
				+ (372950 - 171550) * 0.33 + (income - 372950) * 0.35;
			break;
		case 2:
			if (income <= 16700)
				tax = income * 0.10;
			else if (income <= 67900)
				tax = 16700 * 0.10 + (income - 16700) * 0.15;
			else if (income <= 137050)
				tax = 16700 * 0.10 + (67900 - 16700) * 0.15 + 
				(income - 67900) * 0.25;
			else if (income <= 208850)
				tax = 16700 * 0.10 + (67900 - 16700) * 0.15 + 
				(137050 - 67900) * 0.25 + (income - 137050) * 0.28;
			else if (income <= 372950)
				tax = 16700 * 0.10 + (67900 - 16700) * 0.15 + 
				(137050 - 67900) * 0.25 + (372950 - 137050) * 0.28
				+ (income - 208850) * 0.33;
			else 
				tax = 16700 * 0.10 + (67900 - 16700) * 0.15 + 
				(137050 - 67900) * 0.25 + (372950 - 137050) * 0.28
				+ (372950 - 208850) * 0.33 + (income - 372950) * 0.35;
			break;
		case 3:
			if (income <= 8350)
				tax = income * 0.10;
			else if (income <= 33950)
				tax = 8350 * 0.10 + (income - 8350) * 0.15;
			else if (income <= 68525)
				tax = 8350 * 0.10 + (33950 - 8350) * 0.15 + 
				(income - 33950) * 0.25;
			else if (income <= 104425)
				tax = 8350 * 0.10 + 33950 * 0.15 + 
				(68525 - 33950) * 0.25 + (income - 68525) * 0.28;
			else if (income <= 186475)
				tax = 8350 * 0.10 + 33950 * 0.15 + 
				(68525 - 33950) * 0.25 + (104425 - 68525) * 0.28
				+ (income - 104425) * 0.33;
			else
				tax = 8350 * 0.10 + 33950 * 0.15 + 
				(68525 - 33950) * 0.25 + (104425 - 68525) * 0.28
				+ (186475 - 104425) * 0.33 + (income - 186475) * 0.35;
			break;
		case 4:
			if (income <= 11950)
				tax = income * 0.10;
			else if (income <= 45500)
				tax = 11950 * 0.10 + (income - 11950) * 0.15;
			else if (income <= 117450)
				tax = 11950 * 0.10 + (45500 - 11950) * 0.15 + 
				(income - 45500) * 0.25;
			else if (income <= 190200)
				tax = 11950 * 0.10 + (45500 - 11950) * 0.15 + 
				(117450- 45500) * 0.25 + (income - 117450) * 0.28;
			else if (income <= 372950)
				tax = 11950 * 0.10 + (45500 - 11950) * 0.15 + 
				(117450- 45500) * 0.25 + (190200 - 117450) * 0.28
				+ (income - 190200) * 0.33;
			else
				tax = 11950 * 0.10 + (45500 - 11950) * 0.15 + 
				(117450- 45500) * 0.25 + (190200 - 117450) * 0.28
				+ (372950 - 190200) * 0.33 + (income - 372950) * 0.35;
			break;
		}
		return tax;
	}
}
