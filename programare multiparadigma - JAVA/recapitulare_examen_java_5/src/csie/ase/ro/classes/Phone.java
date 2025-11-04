package csie.ase.ro.classes;

import java.io.Serializable;
import java.util.Objects;

public class Phone implements Cloneable, Serializable {
	static final long serialVersionUID = 1L;
	private String model;
	private String manufacturer;
	private double price;
	
	//Getters & Setters
	public String getModel() {
		return model;
	}
	
	public void setModel(String model) {
		this.model = model;
	}
	
	public String getManufacturer() {
		return manufacturer;
	}
	
	public void setManufacturer(String manufacturer) {
		this.manufacturer = manufacturer;
	}
	
	public double getPrice() {
		return price;
	}
	
	public void setPrice(double price) {
		if(price > 0) {
			this.price = price;
		} else {
			throw new IllegalArgumentException("The price must be greater than 0!");
		}
	}
	
	//Constructors
	public Phone() {
		this.model = "Unknown";
		this.manufacturer = "Unknown";
		this.price = 0;
	}
	
	public Phone(String model, String manufacturer, double price) {
		super();
		this.model = model;
		this.manufacturer = manufacturer;
		this.price = price;
	}
	
	//Override / Implements Methods
	@Override
	public Object clone() throws CloneNotSupportedException {
		Phone copy = new Phone(this.getModel(), this.getManufacturer(), this.getPrice());
		return (Object)copy;
	}
	
	@Override
	public boolean equals(Object obj) {
		 if (this == obj) return true;
		 if(obj == null || getClass() != obj.getClass()) return false;
		 Phone other = (Phone) obj;
		 return this.model.equals(other.model) &&
		           this.manufacturer.equals(other.manufacturer) &&
		           Double.compare(this.price, other.price) == 0;
	}
	
	@Override
	public String toString() {
		return this.getManufacturer() + " " + this.getModel() + ", Price: " + this.getPrice();
	}
	
	@Override
	public int hashCode() {
		return Objects.hash(model, manufacturer, price);
	}
}