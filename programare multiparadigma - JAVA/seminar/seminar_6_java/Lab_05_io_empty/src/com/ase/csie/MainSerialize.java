package com.ase.csie;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.time.LocalDateTime;

import com.ase.csie.java.io.Guest;
import com.ase.csie.java.io.Transaction;

public class MainSerialize {

	public static void main(String[] args) {
		try {
			FileOutputStream fos = new FileOutputStream("test1.txt");
			BufferedOutputStream bos = new BufferedOutputStream(fos);
			ObjectOutputStream oos = new ObjectOutputStream(bos);
			
			Guest g1 = new Guest("Alice");
			Transaction t1 = new Transaction(2, g1, LocalDateTime.now(), new String[] {"Double Room"}, new float[] {125, 300, 155});
			
			oos.writeObject(g1);
			oos.writeObject(t1);
			
			Transaction t2 = new Transaction(3,new Guest("Bree"), LocalDateTime.now(), new String[] {"Suite"}, new float[] {125, 300, 155});
			
			oos.writeObject(t2);
			
			oos.close();
			
			FileInputStream fis = new FileInputStream("test1.txt");
			BufferedInputStream bis = new BufferedInputStream(fis);
			DataInputStream dis = new DataInputStream(bis);
			
			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
