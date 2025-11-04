package csie.ase.classes;

import java.io.Serializable;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import csie.ase.utils.*;

public class Airplane implements Cloneable, Serializable, Comparable<Airplane>, AirplaneCalculator{
	private static final long serialVersionUID = 1L;
	private int id;
	private String insuranceCompany;
	private double distance;
	private double kerosenConsumption;
	private List<AirplaneExpense> expenses;
	private LocalDateTime day;
	
	//Setters & Getters
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public String getInsuranceCompany() {
		return insuranceCompany;
	}
	
	public void setInsuranceCompany(String insuranceCompany) {
		this.insuranceCompany = insuranceCompany;
	}
	
	public double getDistance() {
		return distance;
	}

	public void setDistance(double distance) {
		this.distance = distance;
	}

	public double getKerosenConsumption() {
		return kerosenConsumption;
	}

	public void setKerosenConsumption(double kerosenConsumption) {
		this.kerosenConsumption = kerosenConsumption;
	}

	public List<AirplaneExpense> getExpenses() {
		return expenses;
	}
	
	public void setExpenses(List<AirplaneExpense> expenses) {
		if(expenses != null) {
			this.expenses = new ArrayList<>();
			for(AirplaneExpense x : expenses) {
				this.expenses.add(x);
			}
		}
	}
	
	public LocalDateTime getDay() {
		return day;
	}
	
	public void setDay(LocalDateTime day) {
		this.day = day;
	}
	
	//Constructors
	public Airplane() {
		this.id = 0;
		this.insuranceCompany = "Unknown";
		this.distance = 0;
		this.kerosenConsumption = 0;
		this.expenses = new ArrayList<>();
		this.day = LocalDateTime.now();
	}

	public Airplane(int id, String insuranceCompany, double distance, double kerosenConsumption,
			List<AirplaneExpense> expenses, LocalDateTime day) {
		super();
		this.id = id;
		this.insuranceCompany = insuranceCompany;
		this.distance = distance;
		this.kerosenConsumption = kerosenConsumption;
		this.expenses = new ArrayList<>();
		if(expenses != null) {
			for(AirplaneExpense x : expenses) {
				this.expenses.add(x);
			}
		}

		this.day = day;
	}

	//Methods

	@Override
	public int hashCode() {
		return Objects.hash(this.id, this.insuranceCompany, this.distance, this.kerosenConsumption, this.expenses.hashCode(), this.day);
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || this.getClass() != obj.getClass()) return false;
		Airplane x = (Airplane) obj;
		return Integer.compare(this.id, x.id) == 0 && this.insuranceCompany.equals(x.insuranceCompany) && Double.compare(this.distance, x.distance) == 0
				&& Double.compare(this.kerosenConsumption, kerosenConsumption) == 0 && this.expenses.equals(x.expenses) && this.day.equals(x.day);
	}

	@Override
	public Airplane clone() throws CloneNotSupportedException {
		return new Airplane(id, insuranceCompany, distance, kerosenConsumption, expenses, day);
	}

	@Override
	public String toString() {
		return "Airplane " + this.id + ", insurance: " + this.insuranceCompany + ", kerosen consumption: "+ this.getKerosenConsumption() +
				", total expenses: " + this.getTotalExpenses();
	}

	@Override
	public int compareTo(Airplane o) {
		return Double.compare(this.kerosenConsumption, o.kerosenConsumption);
	}

	@Override
	public double getTotalExpenses() {
		double sum = 0;
		if(this.expenses != null) {
			for(AirplaneExpense x : this.expenses) {
				sum += x.getValue();
			}
		}
		return sum;
	}
	
	@Override
	public double getConsPerMile() {
		return this.kerosenConsumption/ this.distance;
	}
}
