package assg03;

import java.util.Random;

public class ProgMain {

	public static void main(String[] args) {
		int[] numArr = new int[15];
		insert(numArr);
		System.out.print("The array: ");
		for (int i = 0; i < numArr.length; i++) {
			System.out.print(numArr[i] + " ");
		}
		System.out.println();
		double avg = avgArr(numArr);
		System.out.println("The average: " + avg);
		int count = count(numArr, avg);
		System.out.println("There are " + count + " numbers above the average.");
	}

	public static void insert(int[] numArr) {
		Random number = new Random();
		for (int i = 0; i < numArr.length; i++) {
			numArr[i] = number.nextInt(101);
		}
	}
	
	public static double avgArr(int[] arr) {
		int val = 0;
		for (int i = 0; i < arr.length; i++) {
			val += arr[i];
		}
		return val/arr.length;
	}
	
	public static int count(int[] arr, double val) {
		int count = 0;
		for (int i = 0; i < arr.length; i++) {
			if (arr[i] > val) {
				count++;
			}
		}
		return count;
	}

}
