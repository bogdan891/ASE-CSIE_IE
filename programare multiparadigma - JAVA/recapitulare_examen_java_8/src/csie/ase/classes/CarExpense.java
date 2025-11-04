package csie.ase.classes;

import java.io.Serializable;
import java.util.Objects;

public class CarExpense implements Serializable, Cloneable {
	private static final long serialVersionUID = 1L;
	private String type;
	private double value;
	
	//Getter & Setters
	public String getType() {
		return type;
	}
	
	public void setType(String type) {
		this.type = type;
	}
	
	public double getValue() {
		return value;
	}
	
	public void setValue(double value) {
		if(value > 0) {
			this.value = value;
		} else {
			throw new IllegalArgumentException("The value of expense [" + this.type + "] must be positive!");
		}
	}
	
	//Constructors
	public CarExpense() {
		this.type = "General";
		this.value = 0;
	}

	public CarExpense(String type, double value) {
		super();
		this.type = type;
		this.value = value;
	}
	
	//Methods
	@Override
	public int hashCode() {
		return Objects.hash(this.type, this.value);
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || getClass() != obj.getClass()) return false;
		CarExpense x = (CarExpense) obj;
		return this.type.equals(x.type) && Double.compare(this.value,  x.value) == 0;
	}

	@Override
	public CarExpense clone() throws CloneNotSupportedException {
		return new CarExpense(type, value);
	}
}
