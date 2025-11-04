package dice.ase.ro;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.Serializable;

public class MobilePhone extends Phone implements Cloneable, Chargeable, Serializable{
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
	public int compareTo(Phone other) {
	    if (other instanceof MobilePhone) {
	        MobilePhone m = (MobilePhone) other;
	        int cmp = Double.compare(this.getPrice(), m.getPrice());
	        if (cmp != 0) return cmp;
	        return Integer.compare(this.getBatteryLevel(), m.getBatteryLevel());
	    }
	    return super.compareTo(other);
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
	
	public void SaveMobilePhone2File() {
		boolean append = true;
		try(DataOutputStream dos = new DataOutputStream(new BufferedOutputStream(new FileOutputStream("phones.txt", append)))){
			dos.writeUTF(getModel());
			dos.writeUTF(getManufacturer());
			dos.writeDouble(getPrice());
			dos.writeBoolean(isIs5G());
			dos.writeInt(getBatteryLevel());
		} catch(IOException e) {
			e.printStackTrace();
		}
	}
	
	public static MobilePhone ReadFromFile() {
		MobilePhone mp = new MobilePhone();
		try(DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream("phones.txt")))){
			mp.setModel(dis.readUTF());
			mp.setManufacturer(dis.readUTF());
			mp.setPrice(dis.readDouble());
			mp.setIs5G(dis.readBoolean());
			mp.setBatteryLevel(dis.readInt());
		} catch (IOException e) {
			e.printStackTrace();
		}
		return mp;
	}
}
