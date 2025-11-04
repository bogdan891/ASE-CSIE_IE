package com.ase.csie.java.io;

import java.io.BufferedOutputStream;
import java.io.DataOutputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class Transaction implements Cloneable {
	private int id;
	private Guest guest;
	private LocalDateTime date;
	private String[] items;
	private float[] prices;
	
	public Transaction(int id, Guest guest, LocalDateTime date, String[] items, float[] prices) {
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
	
	public void saveTransaction2File(String invoiceFileName) {
		try {
			FileOutputStream fos = new FileOutputStream(invoiceFileName);
			BufferedOutputStream bos = new BufferedOutputStream(fos);
			DataOutputStream dos = new DataOutputStream(bos);
			
			dos.writeInt(this.id);
			dos.writeUTF(this.guest.getName());
			dos.writeUTF(this.date.format(DateTimeFormatter.ISO_DATE_TIME));
			
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public double readTransactionFromFileAndCalcTotal(String invoiceFileName) {
		return 0;
	}

	@Override
	public Transaction clone() throws CloneNotSupportedException {
		return (Transaction) super.clone();
	}
	
	
}
