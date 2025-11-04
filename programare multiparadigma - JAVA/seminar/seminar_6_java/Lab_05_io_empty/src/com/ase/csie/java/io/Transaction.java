package com.ase.csie.java.io;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.EOFException;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Arrays;

public class Transaction implements Cloneable, Serializeable {
	private int id;
	private Guest guest;
	private LocalDateTime date;
	private String[] items;
	private float[] prices;
	
	public Transaction(int id, Guest guest, LocalDateTime date, String[] items, float[] prices) {
		super();
		this.id = id;
		this.guest = guest;
		this.date = date;
		this.items = items;
		this.prices = prices;
	}
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public Guest getGuest() {
		return guest;
	}
	public void setGuest(Guest guest) {
		this.guest = guest;
	}
	public LocalDateTime getDate() {
		return date;
	}
	public void setDate(LocalDateTime date) {
		this.date = date;
	}
	public String[] getItems() {
		return items;
	}
	public void setItems(String[] items) {
		this.items = items;
	}
	public float[] getPrices() {
		return prices;
	}
	public void setPrices(float[] prices) {
		this.prices = prices;
	}
	
	@Override
	public Transaction clone() throws CloneNotSupportedException {
		Transaction clone =  (Transaction)super.clone();
		Guest cloneGuest = new Guest(this.guest.getName());
		clone.setGuest(cloneGuest);
		
		String[] cloneItems = this.items.clone();
		float[] clonePrices = this.prices.clone();
		
		clone.setItems(cloneItems);
		clone.setPrices(clonePrices);
		return clone;
	}

	
	public void saveTransaction2File(String invoiceFileName) throws IOException {
		DataOutputStream dos = null;
		try {
			FileOutputStream fos = new FileOutputStream(invoiceFileName);
			BufferedOutputStream bos = new BufferedOutputStream(fos);
			dos = new DataOutputStream(bos);
			
			dos.writeInt(this.id);
			//pentru string: writeUTF
			dos.writeUTF(this.guest.getName());
			dos.writeUTF(this.date.format(DateTimeFormatter.ISO_DATE_TIME));
			for(int i=0;i<this.prices.length;i++) {
				dos.writeUTF(this.items[i]);
				dos.writeFloat(this.prices[i]);
			}
			
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} finally {
			dos.close();
		}
	}
	
	public double readTransactionFromFileAndCalcTotal(String invoiceFileName) {
		double total = 0;
		
		try {
			FileInputStream fis = new FileInputStream(invoiceFileName);
			BufferedInputStream bis = new BufferedInputStream(fis);
			DataInputStream dis = new DataInputStream(bis);
			
			int id = 0;
			Guest guest = null;
			LocalDateTime date = null;
			String item;
			float price;
			
			id = dis.readInt();
			guest = new Guest(dis.readUTF());
			date = LocalDateTime.parse(dis.readUTF(), DateTimeFormatter.ISO_DATE_TIME);
			
			try {
				while(true) {
					item = dis.readUTF();
					price = dis.readFloat();
					
					System.out.printf("\n %s %f", item, price);
					total += price;
				}
			} catch (EOFException ef) {
				
			}
			
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return total;
	}
	
}
