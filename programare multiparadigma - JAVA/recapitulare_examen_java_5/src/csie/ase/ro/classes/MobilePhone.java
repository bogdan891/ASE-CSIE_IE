package csie.ase.ro.classes;

import java.io.Serializable;
import java.util.Objects;

import csie.ase.interfaces.*;

public class MobilePhone extends Phone implements Cloneable, Chargeable, Serializable, Comparable<MobilePhone>{
	private static final long serialVersionUID = 1L;
	private int batteryLevel;
	private boolean is5G;
	
	//Getters & Setters 
	public int getBatteryLevel() {
		return batteryLevel;
	}
	
	public void setBatteryLevel(int batteryLevel) {
		if(batteryLevel >= 0) {
			this.batteryLevel = batteryLevel;
		} else {
			throw new IllegalArgumentException("The battery level must be positive!");
		}
	}
	
	public boolean isIs5G() {
		return is5G;
	}
	
	public void setIs5G(boolean is5g) {
		is5G = is5g;
	}
	
	//Constructors
	public MobilePhone() {
		super();
		this.batteryLevel = 100;
		this.is5G = false;
	}
	
	public MobilePhone(String model, String manufacturer, double price, int batteryLevel, boolean is5G) {
		super(model, manufacturer, price);
		this.batteryLevel = batteryLevel;
		this.is5G = is5G;
	}

	public MobilePhone(String model, String manufacturer, double price) {
		super(model, manufacturer, price);
	}

	//Override / Implements methods
	@Override
	public MobilePhone clone() throws CloneNotSupportedException {
		return new MobilePhone(this.getModel(), this.getManufacturer(), this.getPrice(), this.getBatteryLevel(), this.is5G);
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(!super.equals(obj)) return false;
		if(getClass() != obj.getClass()) return false;
		
		MobilePhone other = (MobilePhone) obj;
		return this.batteryLevel == other.batteryLevel &&
				this.is5G == other.is5G;
	}

	@Override
	public String toString() {
		return super.toString() + " / 5G? " + (this.is5G ? "Yes" : "No") + " / Battery level: " + this.getBatteryLevel() + "%";
	}
	
	@Override
	public int compareTo(MobilePhone other) {
	    int cmp = Double.compare(this.getPrice(), other.getPrice());
	    if (cmp != 0) return cmp;
	    return Integer.compare(this.getBatteryLevel(), other.getBatteryLevel());
	}
	
	
	
	@Override
	public int hashCode() {
		return Objects.hash(super.hashCode(), this.getBatteryLevel(), this.isIs5G());
	}

	@Override
	public void chargePhone(int value) {
		if(value < 0) throw new IllegalArgumentException("The value of charging must be positive!");
		if(this.getBatteryLevel() + value > 100) {
			this.setBatteryLevel(100);
		} else {
			int aux = this.getBatteryLevel() + value;
			this.setBatteryLevel(aux);
		}
	}
}
