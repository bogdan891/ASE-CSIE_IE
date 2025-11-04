package csie.ase.classes;

import java.io.Serializable;
import java.util.Objects;

public class AirplaneExpense implements Cloneable, Serializable {
	private static final long serialVersionUID = 1L;
	private String type;
	private double value;
	
	//Getters & Setters
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
			throw new IllegalArgumentException("The value of expense must positive!");
		}
	}
	
	//Constructors
	public AirplaneExpense() {
		this.type = "General";
		this.value = 0;
	}

	public AirplaneExpense(String type, double value) {
		super();
		this.type = type;
		this.value = value;
	}
	
	//Methods
	@Override
	public int hashCode() {
		return Objects.hash(this.getType(), this.getValue());
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || this.getClass() != obj.getClass()) return false;
		AirplaneExpense x = (AirplaneExpense) obj;
		return this.getType().equals(x.getType()) && Double.compare(this.getValue(), x.getValue()) == 0;
	}

	@Override
	public AirplaneExpense clone() throws CloneNotSupportedException {
		return new AirplaneExpense(this.getType(), this.getValue());
	}
}
