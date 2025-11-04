package csie.ase.classes;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import csie.ase.utils.CarCalculator;

public class Car implements Serializable, Cloneable, Comparable<Car>, CarCalculator {
	private static final long serialVersionUID = 1L;
	private int id;
	private String registrationPlate;
	private String insuranceCompany;
	private double distance;
	private List<CarExpense> expenses;
	
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
	
	public String getRegistrationPlate() {
		return registrationPlate;
	}
	
	public void setRegistrationPlate(String registrationPlate) {
		this.registrationPlate = registrationPlate;
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
		if(distance > 0) {
			this.distance = distance;
		}  else {
			throw new IllegalArgumentException("The distance must be positive!");
		}
	}
	
	public List<CarExpense> getExpenses() {
		return expenses;
	}
	
	public void setExpenses(List<CarExpense> expenses) {
		if(expenses != null) {
			this.expenses = new ArrayList<CarExpense>();
			for(CarExpense x : expenses) {
				this.expenses.add(x);
			}
		}
	}
	
	//Constructors
	public Car() {
		this.id = 0;
		this.registrationPlate = "B-000-AAA";
		this.insuranceCompany = "Alibaba";
		this.distance = 0;
		this.expenses = new ArrayList<CarExpense>();
	}

	public Car(int id, String registrationPlate, String insuranceCompany, double distance, List<CarExpense> expenses) {
		super();
		this.id = id;
		this.registrationPlate = registrationPlate;
		this.insuranceCompany = insuranceCompany;
		this.distance = distance;
		this.expenses = new ArrayList<CarExpense>();
		if(expenses != null) {
			for(CarExpense x : expenses) {
				this.expenses.add(x);
			}
		}
	}
	
	//Methods
	@Override
	public int hashCode() {
		return Objects.hash(this.id, this.registrationPlate, this.insuranceCompany, this.distance, this.expenses.hashCode());
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || getClass() != obj.getClass()) return false;
		Car x = (Car) obj;
		return Integer.compare(this.id,  x.id) == 0 && this.registrationPlate.equals(x.registrationPlate) 
				&& this.insuranceCompany.equals(x.insuranceCompany) && Double.compare(this.distance, x.distance) == 0
				&& this.expenses.equals(x.expenses);
	}

	@Override
	public Car clone() throws CloneNotSupportedException {
		return new Car(id, registrationPlate, insuranceCompany, distance, expenses);
	}

	@Override
	public String toString() {
		return "Car " + this.id + ", insurance: " + this.insuranceCompany + ", distance: " + this.distance;
	}

	@Override
	public int compareTo(Car o) {
		return Double.compare(this.distance, o.distance);
	}

	@Override
	public double getTotalExpense() {
		double sum = 0;
		sum +=  (this.expenses.get(0).getValue()) * ( this.expenses.get(1).getValue());
		for(int i = 2; i < this.expenses.size(); i++) {
			sum += this.expenses.get(i).getValue();
		}
		return sum;
	}
}
