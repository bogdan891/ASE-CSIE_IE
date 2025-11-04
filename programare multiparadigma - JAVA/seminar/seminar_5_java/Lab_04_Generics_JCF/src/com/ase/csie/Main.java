package com.ase.csie;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.TreeMap;

import com.ase.csie.java.HotelRoom;
import com.ase.csie.java.SingleRoom;
import com.ase.csie.java.Suite;
import com.ase.csie.java.Transaction;
import com.ase.csie.java.Amenity;

public class Main {
	public static void main(String[] args) {
		List<HotelRoom> hotel = new  LinkedList<>();
		
		for (int i = 0; i < 10; i++) {
			hotel.add(new SingleRoom(i, "East", 
					new Amenity[] {Amenity.TV, Amenity.WIFI, Amenity.MINI_BAR}, 14));
			hotel.add(new Suite(i, "West", new Amenity[] {Amenity.WIFI}, 2));
		}
		
		System.out.println("Hotel capacity: " + hotel.size());
		
//		for (int i = 0; i < hotel.size(); i++) {
//			System.out.println(hotel.get(i));
//			
//			if (i == 1) {
//				hotel.remove(i);
//			}
//		}
		
		Iterator<HotelRoom> it = hotel.iterator();
		while (it.hasNext()) {
			HotelRoom hr = it.next();
			System.out.println(hr);
			if (hr.getRoomNumber() == 3) {
				it.remove();
			}
		}
		
		//Map<Transaction, HotelRoom> map = new Hashtable<>();
		
		Map<Transaction, HotelRoom> map = new TreeMap<>();

		
		for (int i = 0; i < 7; i++) {
			Transaction t = new  Transaction();
			t.setId(i);
			t.setDate(LocalDateTime.now());
			
			HotelRoom hr = new HotelRoom();
			hr.setRoomNumber(i);
			
			map.put(t, hr);
		}
		
		Set<Transaction> keySet = map.keySet();
		
		Iterator<Transaction> it1 = keySet.iterator();
		while (it1.hasNext()) {
			Transaction key = it1.next();
			
			HotelRoom value = map.get(key);
			
			System.out.println("Key: " + key.getId() + ", Value: " + value.getRoomNumber());
		}
	}
}
