package com.ase.csie.java;

public class SingleRoom extends HotelRoom {
	private float area;
	
	public SingleRoom() {
		super();
		System.out.println("HotelRoom:Constructor");
	}
	
	public SingleRoom(int numOfRoom, String location, Amenity[] amenities, float area) {
		super(numOfRoom, location, amenities);
	}

	public float getArea() {
		return area;
	}

	public void setArea(float area) {
		this.area = area;
	}
	
	
}
