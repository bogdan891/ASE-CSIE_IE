package com.ase.csie.java;

public class SingleRoom extends HotelRoom {
	public float area;

	public SingleRoom() {
		this.area = 0;
		System.out.println("SingeRoom:Constructor");
	}

	public SingleRoom(int roomNumber, String location, Amenity[] amenities, float area) {
		super(roomNumber, location, amenities);
		this.area = area;
	}

	public float getArea() {
		return area;
	}

	public void setArea(float area) {
		this.area = area;
	}

	@Override
	public String toString() {
		return new String("SingleRoom nr " + this.getRoomNumber() + " has area of " + this.getArea());
	}
	
	@Override
	public void bookRoom() {
		System.out.println("Single room was booked");
		super.setAvailable(false);
	}

}
