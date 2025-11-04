package csie.ase.classes;

import java.io.Serializable;
import java.util.Objects;

import csie.ase.utils.*;

public class Vehicle implements Cloneable, Serializable {
	private static final long serialVersionUID = 1L;
	String manufacturer;
	String plate;
	FuelType engineFuel;
	
	public Vehicle() {
		this.manufacturer = "N/A";
		this.plate = "N/A";
		this.engineFuel = FuelType.GAS;
	}
	
	public Vehicle(String manufacturer, String plate, FuelType engineFuel) {
		super();
		this.manufacturer = manufacturer;
		this.plate = plate;
		this.engineFuel = engineFuel;
	}

	public String getManufacturer() {
		return manufacturer;
	}

	public void setManufacturer(String manufacturer) {
		this.manufacturer = manufacturer;
	}

	public String getPlate() {
		return plate;
	}

	public void setPlate(String plate) {
		this.plate = plate;
	}

	public FuelType getEngineFuel() {
		return engineFuel;
	}

	public void setEngineFuel(FuelType engineFuel) {
		this.engineFuel = engineFuel;
	}

	@Override
	public int hashCode() {
		return Objects.hash(this.getManufacturer(), this.getPlate(), this.getEngineFuel());
	}
	
	//Varianta 2 la hashCode
	/*@Override
	public int hashCode() {
		return Objects.hash(this.getManufacturer(), this.getPlate(), this.getEngineFuel());
	}*/

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || this.getClass() != obj.getClass()) return false;
		Vehicle v = (Vehicle) obj;
		return this.getManufacturer().equals(v.getManufacturer()) && this.getPlate().equals(v.getPlate()) 
				&& this.getEngineFuel().name().equals(v.getEngineFuel().name());
	}

	@Override
	protected Vehicle clone() throws CloneNotSupportedException {
		return new Vehicle(this.getManufacturer(), this.getPlate(), this.getEngineFuel());
	}
}
