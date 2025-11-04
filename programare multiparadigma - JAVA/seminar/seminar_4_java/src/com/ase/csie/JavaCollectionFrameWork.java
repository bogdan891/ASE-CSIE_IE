package com.ase.csie;

import com.ase.csie.java.HotelRoom;
import com.ase.csie.java.Amenity;
import com.ase.csie.java.SingleRoom;
import com.ase.csie.java.Suite;
import com.ase.csie.java.HotelActions;
import com.ase.csie.java.Guest;
import java.util.ArrayList;
import java.util.List;

public class JavaCollectionFrameWork {
	public static void main(String[] args) {
		List<HotelRoom> hotel = new ArrayList<>();
		hotel.add(new HotelRoom());
		hotel.get(0);
		
		for (int i = 0; i < 10; i++) {
			hotel.add(new SingleRoom(i, "East", new Amenity[] {Amenity.TV}, 3));
		}
		
		for (int i = 0; i < 10; i++) {
			hotel.add(new Suite(i, "East", new Amenity[] {Amenity.TV}, 3));
		}
		
		for (int i = 0; i < 10; i++) {
			System.out.println(hotel.get(i));
		}
	}
}
