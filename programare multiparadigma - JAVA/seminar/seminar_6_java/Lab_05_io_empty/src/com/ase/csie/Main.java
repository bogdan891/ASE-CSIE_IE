package com.ase.csie;

import java.io.EOFException;
import java.io.IOException;
import java.time.LocalDateTime;
import java.util.Scanner;

import com.ase.csie.java.io.Guest;
import com.ase.csie.java.io.Transaction;

public class Main {

	// create Transaction class which contains:
	// A. Fields:
	// A.1 - id: int
	// A.2 - guest: Guest
	// A.3 - date: LocalDateTime
	// A.4 - items: String[] - products within transaction
	// A.5 - prices: float[] - product prices
	// B. Methods:
	// B.1 - constructor: public Transaction(int id, Guest guest, LocalDateTime
	// date, String[] items, float[] prices)
	// B.2 - get and set methods
	// B.3 - public void saveTransaction2File(String invoiceFileName) - save the
	// transaction values (in order of the described fields)
	// into a file
	// B.4 - public double readTransactionFromFileAndCalcTotal(String
	// invoiceFileName) - read from the file and calculate
	// the total of the transaction
	// B.5 - clone method for deep copy

	public static void main(String[] args) {
		String[] items = new String[] {"Single Room", "Suite", "Suite"};
		float[] prices = new float[] {125.5f, 180, 200};
		
		Transaction t1 = new Transaction(1, new Guest("Alice"), LocalDateTime.now(), items, prices);
		try {
			t1.saveTransaction2File("test2.txt");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		t1.readTransactionFromFileAndCalcTotal("test2.txt");
		
	}

}
