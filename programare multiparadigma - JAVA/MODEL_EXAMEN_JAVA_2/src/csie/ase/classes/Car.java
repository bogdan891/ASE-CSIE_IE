package csie.ase.classes;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import csie.ase.utils.CarCalculator;

public class Car implements Serializable, Cloneable, Comparable<Car>, CarCalculator {
	private static final long serialVersionUID = 1L;

	private String licensePlate;
	private String insuranceCompany;
	private List<CarExpense> expenses;
	private double distanceKm;
	private double gasConsumption;

	// === Constructori ===

	public Car() {
		this.licensePlate = this.insuranceCompany = "Unknown";
		this.expenses = new ArrayList<>();
		this.distanceKm = 0;
		this.gasConsumption = 0;
	}

	public Car(String licensePlate, String insuranceCompany, List<CarExpense> expenses) {
		this.licensePlate = licensePlate;
		this.insuranceCompany = insuranceCompany;
		this.expenses = new ArrayList<>();
		if (expenses != null) {
			for (CarExpense x : expenses) {
				try {
					this.expenses.add(x.clone());
				} catch (CloneNotSupportedException e) {
					e.printStackTrace();
				}
			}
		}
		this.distanceKm = 0;
		this.gasConsumption = 0;
	}

	// === Getters & Setters ===

	public String getLicensePlate() {
		return licensePlate;
	}

	public void setLicensePlate(String licensePlate) {
		this.licensePlate = licensePlate;
	}

	public String getInsuranceCompany() {
		return insuranceCompany;
	}

	public void setInsuranceCompany(String insuranceCompany) {
		this.insuranceCompany = insuranceCompany;
	}

	public List<CarExpense> getExpenses() {
		return List.copyOf(expenses);
	}

	public void setExpenses(List<CarExpense> expenses) {
		this.expenses = new ArrayList<>();
		if (expenses != null) {
			for (CarExpense x : expenses) {
				try {
					this.expenses.add(x.clone());
				} catch (CloneNotSupportedException e) {
					e.printStackTrace();
				}
			}
		}
	}

	public double getDistanceKm() {
		return distanceKm;
	}

	public void setDistanceKm(double distanceKm) {
		if (distanceKm < 0) {
			throw new IllegalArgumentException("Distance must be non-negative.");
		}
		this.distanceKm = distanceKm;
	}

	public double getGasConsumption() {
		return gasConsumption;
	}

	public void setGasConsumption(double gasConsumption) {
		if (gasConsumption < 0) {
			throw new IllegalArgumentException("Gas consumption must be non-negative.");
		}
		this.gasConsumption = gasConsumption;
	}

	// === Funcționalități ===

	@Override
	public double getTotalExpenses() {
		double sum = 0;
		for (CarExpense x : expenses) {
			sum += x.getAmount();
		}
		return sum;
	}

	public double getCostPerKm() {
		return distanceKm > 0 ? getTotalExpenses() / distanceKm : 0;
	}

	@Override
	public boolean equals(Object o) {
		if (this == o) return true;
		if (o == null || getClass() != o.getClass()) return false;
		Car car = (Car) o;
		return Double.compare(car.distanceKm, distanceKm) == 0 &&
		       Double.compare(car.gasConsumption, gasConsumption) == 0 &&
		       Objects.equals(licensePlate.toLowerCase(), car.licensePlate.toLowerCase()) &&
		       Objects.equals(insuranceCompany.toLowerCase(), car.insuranceCompany.toLowerCase()) &&
		       Objects.equals(expenses, car.expenses);
	}

	@Override
	public int hashCode() {
		return Objects.hash(
			licensePlate.toLowerCase(),
			insuranceCompany.toLowerCase(),
			distanceKm,
			gasConsumption,
			expenses
		);
	}

	@Override
	public int compareTo(Car other) {
		return Double.compare(this.getTotalExpenses(), other.getTotalExpenses());
	}

	@Override
	public Car clone() throws CloneNotSupportedException {
		List<CarExpense> clonedExpenses = new ArrayList<>();
		for (CarExpense exp : this.expenses) {
			clonedExpenses.add(exp.clone());
		}
		Car cloned = new Car(this.licensePlate, this.insuranceCompany, clonedExpenses);
		cloned.setDistanceKm(this.distanceKm);
		cloned.setGasConsumption(this.gasConsumption);
		return cloned;
	}

	@Override
	public String toString() {
		return licensePlate + " (" + insuranceCompany + 
		       ") -> Total expenses: " + getTotalExpenses() + " RON, Cost/km: " + getCostPerKm();
	}
}
