package com.ase.csie.java;

public class HotelRoom implements Cloneable {
	public static int noRooms;
	
	private int numOfRooms;
	private String location;
	private float price;
	private boolean isAvailable = true;
	private Amenity[] amenities;
	
	public HotelRoom(int numOfRooms, String location, Amenity[] amenities) {
		super();
		this.numOfRooms = numOfRooms;
		this.location = location;
		this.amenities = new Amenity[amenities.length];
		for(int i=0; i < amenities.length; i++) {
			this.amenities[i] = amenities[i];
		}
		
		HotelRoom.noRooms++;
	}

	public int getNumOfRooms() {
		return numOfRooms;
	}

	public void setNumOfRooms(int numOfRooms) {
		this.numOfRooms = numOfRooms;
	}

	public String getLocation() {
		return location;
	}

	public void setLocation(String location) {
		this.location = location;
	}

	public boolean isAvailable() {
		return isAvailable;
	}

	public void setAvailable(boolean isAvailable) {
		this.isAvailable = isAvailable;
	}

	public Amenity[] getAmenities() {
		return amenities;
	}

	public void setAmenities(Amenity[] amenities) {
		this.amenities = amenities;
	}

	public float getPrice() {
		this.price = calculatePrice();
		return price;
	}

	private float calculatePrice() {
		float startPrice = 100;
		
		for (Amenity a : this.amenities) {
			switch(a) {
			case WIFI:
				startPrice += 25;
				break;
			case TV:
				startPrice += 10;
				break;
			case MINI_BAR:
				startPrice += 15.5;
				break;
			default:
				break;
			}
		}
		
		return startPrice;
	}

	@Override
	public HotelRoom clone() throws CloneNotSupportedException {
		// TODO Auto-generated method stub
		HotelRoom clone = (HotelRoom) super.clone();
		clone.amenities = this.amenities.clone();
		clone.location = new String(this.location);
		noRooms++;
		return clone;
	}
	
	
	
	
	
}
