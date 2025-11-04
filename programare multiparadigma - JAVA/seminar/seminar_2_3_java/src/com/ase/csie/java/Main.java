package com.ase.csie.java;

public class Main {
	public static void main(String[] args) {
		
		Amenity[] a1 = new Amenity[] {Amenity.MINI_BAR, Amenity.TV};
		HotelRoom hr1 = new HotelRoom(1, "Beach View", a1);
		
															// (!) Anonymous object (!)
		HotelRoom hr2 = new HotelRoom(2, "City View", 
				new Amenity[] {Amenity.MINI_BAR, Amenity.TV, Amenity.WIFI});
		
		HotelRoom[] hotel = new HotelRoom[HotelRoom.noRooms];
		hotel[0] = hr1;
		hotel[1] = hr2;
		
		try {
			HotelRoom hr3 = hr2.clone();
		} catch (CloneNotSupportedException e) {
			e.printStackTrace();
		}
		
		for (HotelRoom hr : hotel) {
			System.out.println("The price for room " + hr.getNumOfRooms() + " is " + hr.getPrice());
		}
	}
}
