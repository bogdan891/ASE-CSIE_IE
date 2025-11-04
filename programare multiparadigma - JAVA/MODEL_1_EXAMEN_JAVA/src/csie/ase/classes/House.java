package csie.ase.classes;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

public class House implements Cloneable, Serializable, Comparable<House> {
	private static final long serialVersionUID = 1L;
	private int id_house;
	private String location;
	private String admin_company;
	private List<Expense> expenses;
	 
	 //Getters and Setters
	public int getId_house() {
		return id_house;
	}
	
	public void setId_house(int id_house) {
		if(id_house > 0) {
			this.id_house = id_house;
		} else {
			throw new IllegalArgumentException("The id must be a positive number!");
		}
	}
	
	public String getLocation() {
		return location;
	}
	
	public void setLocation(String location) {
		this.location = location;
	}
	
	public String getAdmin_company() {
		return admin_company;
	}
	
	public void setAdmin_company(String admin_company) {
		this.admin_company = admin_company;
	}
	
	public List<Expense> getExpenses() {
		return List.copyOf(expenses);
	}
	
	public void setExpenses(List<Expense> expenses) {
		this.expenses = new ArrayList<>();
		if(expenses != null) {
			for(Expense e : expenses) {
				try {
					this.expenses.add(e.clone());
				} catch (CloneNotSupportedException e1) {
					e1.printStackTrace();
				}
			}
		}
	}

	public House() {
	    this.id_house = 0;
	    this.location = "Unkonwn";
	    this.admin_company = "Unknown";
	    this.expenses = new ArrayList<Expense>();
	}
	
	public House(int id_house, String location, String admin_company, List<Expense> expenses) {
		super();
		this.id_house = id_house;
		this.location = location;
		this.admin_company = admin_company;
		this.expenses = List.copyOf(expenses);
	}

	@Override
	public int hashCode() {
		return Objects.hash(id_house, location, admin_company, expenses);
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || this.getClass() != obj.getClass()) return false;
		House h = (House) obj;
		return id_house == h.id_house &&
		           Objects.equals(location, h.location) &&
		           Objects.equals(admin_company, h.admin_company) &&
		           Objects.equals(expenses, h.expenses);
	}

	@Override
	protected House clone() throws CloneNotSupportedException {
		return new House(this.getId_house(), this.getLocation(), this.getAdmin_company(), this.getExpenses());
	}

	@Override
	public String toString() {
		return "House: " + this.getId_house() + ", Location: " + this.getLocation() + ", Admin company: " + this.getAdmin_company();
	}
	
	@Override
	public int compareTo(House other) {
        return Integer.compare(this.id_house, other.id_house);
    }
}
