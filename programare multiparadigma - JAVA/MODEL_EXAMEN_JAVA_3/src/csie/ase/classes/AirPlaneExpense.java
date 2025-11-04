package csie.ase.classes;

import java.io.Serializable;
import java.util.Objects;

public class AirPlaneExpense implements Serializable, Cloneable{
	private static final long serialVersionUID = 1L;
	private String type;
	double cost;
	
	public String getType() {
		return type;
	}
	
	public void setType(String type) {
		this.type = type;
	}
	
	public double getCost() {
		return cost;
	}
	
	public void setCost(double cost) {
		if(cost > 0) {
			this.cost = cost;
		} else {
			throw new IllegalArgumentException("The cost of expense [" + this.getType() + "] must be positive!");
		}
	}
	
	public AirPlaneExpense() {
		this.type = "General";
		this.cost = 0;
	}

	public AirPlaneExpense(String type, double cost) {
		super();
		this.type = type;
		this.cost = cost;
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || this.getClass() != obj.getClass()) return false;
		AirPlaneExpense x = (AirPlaneExpense) obj;
		return this.getType().equals(x.getType()) && Double.compare(this.getCost(), x.getCost()) == 0;
	}

	@Override
	public AirPlaneExpense clone() throws CloneNotSupportedException {
		return new AirPlaneExpense(this.getType(), this.getCost()); 
	}

	@Override
	public int hashCode() {
		return Objects.hash(this.getType(), this.getCost());
	}
}
