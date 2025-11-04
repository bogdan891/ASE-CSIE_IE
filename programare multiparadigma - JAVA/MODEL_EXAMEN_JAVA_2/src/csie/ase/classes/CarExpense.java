package csie.ase.classes;

import java.io.Serializable;
import java.util.Objects;

public class CarExpense implements Serializable, Cloneable {
	private static final long serialVersionUID = 1L;
	private String type;
	private double amount;

	public String getType() {
		return type;
	}
	
	public void setType(String type) {
		this.type = type;
	}
	
	public double getAmount() {
		return amount;
	}
	
	public void setAmount(double amount) {
		if (amount > 0) {
			this.amount = amount;
		} else {
			throw new IllegalArgumentException("The amount value must be positive!");
		}
	}
	
	public CarExpense() {
		this.type = "General";
		this.amount = 0;
	}
	
	public CarExpense(String type, double amount) {
		this.type = type;
		this.amount = amount;
	}

	@Override
	public int hashCode() {
		return Objects.hash(this.type.toLowerCase(), this.amount);
	}

	@Override
	public boolean equals(Object obj) {
	    if (this == obj) return true;
	    if (obj == null || getClass() != obj.getClass()) return false;
	    CarExpense that = (CarExpense) obj;
	    return Double.compare(that.amount, amount) == 0 &&
	           type.equalsIgnoreCase(that.type);
	}

	@Override
	public CarExpense clone() throws CloneNotSupportedException {
		return new CarExpense(this.type, this.amount);
	}

	@Override
	public String toString() {
		return type + ": " + amount + " RON";
	}
}
