package csie.ase.classes;

import java.io.Serializable;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import csie.ase.utils.*;

public class AirPlane implements Cloneable, Serializable, Comparable<AirPlane>, AirPlaneCalculator {
	private static final long serialVersionUID = 1L;
	private int id;
	private String insuranceCompany;
	private double keroseneConsumption;
	private double distance;
	private List<AirPlaneExpense> expenses;
	private LocalDate day;
	
	//Getters & Setters
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		if(id > 0) {
			this.id = id;
		} else {
			throw new IllegalArgumentException("The id must be positive!");
		}
	}
	
	public String getInsuranceCompany() {
		return insuranceCompany;
	}
	
	public void setInsuranceCompany(String insuranceCompany) {
		this.insuranceCompany = insuranceCompany;
	}
	
	public double getKeroseneConsumption() {
		return keroseneConsumption;
	}
	
	public void setKeroseneConsumption(double keroseneConsumption) {
		if(keroseneConsumption > 0) {
			this.keroseneConsumption = keroseneConsumption;
		} else {
			throw new IllegalArgumentException("The kerosene consumption must be positive!");
		}
	}
	
	public double getDistance() {
		return distance;
	}

	public void setDistance(double distance) {
		if(distance > 0) {
			this.distance = distance;
		} else {
			throw new IllegalArgumentException("The distance must be positive!");
		}
	}
	
	public List<AirPlaneExpense> getExpenses() {
		return List.copyOf(expenses);
	}
	
	public void setExpenses(List<AirPlaneExpense> expenses) {
		if(expenses != null) {
			this.expenses = new ArrayList<AirPlaneExpense>();
			for(AirPlaneExpense x : expenses) {
				this.expenses.add(x);
			}
		}
	}
	
	public LocalDate getDay() {
		return day;
	}
	
	public void setDay(LocalDate day) {
		this.day = day;
	}
	
	//Constructors
	public AirPlane() {
		this.id = 0;
		this.insuranceCompany = "Unknown";
		this.keroseneConsumption = 0;
		this.distance = 0;
		this.expenses = new ArrayList<AirPlaneExpense>();
		this.day = LocalDate.now();
	}

	public AirPlane(int id, String insuranceCompany, double keroseneConsumption, double distance, List<AirPlaneExpense> expenses,
			LocalDate day) {
		this.id = id;
		this.insuranceCompany = insuranceCompany;
		this.keroseneConsumption = keroseneConsumption;
		this.distance = distance;
		if(expenses != null) {
			this.expenses = new ArrayList<AirPlaneExpense>();
			for(AirPlaneExpense x : expenses) {
				this.expenses.add(x);
			}
		} else {
			this.expenses = new ArrayList<>();
		}
		this.day = day;
	}
	
	//Methods
	@Override
	public int hashCode() {
		return Objects.hash(id, insuranceCompany, keroseneConsumption, distance, expenses.hashCode(), day);
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || this.getClass() != obj.getClass()) return false;
		AirPlane x = (AirPlane) obj;
		return Integer.compare(this.getId(), x.getId()) == 0 && this.getInsuranceCompany().equals(x.getInsuranceCompany())
				&& Double.compare(this.getKeroseneConsumption(), x.getKeroseneConsumption()) == 0 
				&& Double.compare(this.getDistance(), x.getDistance()) == 0 
				&& this.getExpenses().equals(x.getExpenses());
	}

	@Override
	public AirPlane clone() throws CloneNotSupportedException {
		return new AirPlane(id, insuranceCompany, keroseneConsumption, distance, expenses, day);
	}

	@Override
	public String toString() {
		return "AirPlane: " + this.getId() + ", insurance: " + this.getInsuranceCompany() + ", expenses:" + this.getTotalExpenses() + ", date: " + this.getDay();
	}

	@Override
	public int compareTo(AirPlane o) {
		return Integer.compare(this.getId(), o.getId());
	}

	@Override
	public double getTotalExpenses() {
		int sum = 0;
		if(this.getExpenses() != null) {
			for (AirPlaneExpense x : this.getExpenses()) {
				sum += x.getCost();
			}
		}
		return sum;
	}

	@Override
	public double getKerosenConsumptionCost() {
		return this.getKeroseneConsumption() / this.getDistance();
	}
}
