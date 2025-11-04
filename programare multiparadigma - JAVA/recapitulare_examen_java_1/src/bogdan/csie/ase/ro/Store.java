package bogdan.csie.ase.ro;

import java.util.Objects;

public class Store implements Cloneable, Comparable<Store>{
	private String address;
	private String owner;
	private double area;
	protected static int nbOfStores = 0;
	
	//Getters & Setters
	
	public static int getNbOfStores() {
		return nbOfStores;
	}
	
	public String getAddress() {
		return address;
	}
	
	public void setAddress(String address) {
		this.address = address;
	}
	
	public String getOwner() {
		return owner;
	}
	
	public void setOwner(String owner) {
		this.owner = owner;
	}
	
	public double getArea() {
		return area;
	}
	
	public void setArea(double area) {
		if(area > 0) {
			this.area = area;
		} else {
			throw new IllegalArgumentException("The area of store must be positive!");
		}
	}

	//Constructors
	
	public Store() {
		this.address = "N/A";
		this.owner = "N/A";
		this.area = 0;
		nbOfStores++;
	}
	
	public Store(String address, String owner, double area) {
		this.address = address;
		this.owner = owner;
		this.area = area;
		nbOfStores++;
	}
	
	//Override / Implements methods

	@Override
	public int hashCode() {
		return Objects.hash(this.address, this.owner, this.area);
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || getClass() != obj.getClass()) return false;
		
		Store x = (Store) obj;
		return this.address.equals(x.address) && 
				this.owner.equals(x.owner) && 
				Double.compare(this.area, x.area) == 0;
	}

	@Override
	public Store clone() throws CloneNotSupportedException {
		return new Store(this.address, this.owner, this.area);
	}
	
	@Override
	public int compareTo(Store x) {
		return Double.compare(this.area,  x.area);
	}
}
