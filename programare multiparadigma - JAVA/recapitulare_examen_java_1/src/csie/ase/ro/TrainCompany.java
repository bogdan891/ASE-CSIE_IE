package csie.ase.ro;

import java.util.ArrayList;
import java.util.List;

public class TrainCompany {
	String companyName;
	List<PassengerTrain> trains = new ArrayList<>();
	public static int nbOfTrains = 0;
	
	//Getters & setters
	public String getCompanyName() {
		return companyName;
	}
	
	public void setCompanyName(String companyName) {
		this.companyName = companyName;
	}
	
	public List<PassengerTrain> getTrains() {
		return trains;
	}
	
	public void setTrains(List<PassengerTrain> trains) {
		this.trains = trains;
	}
	
	//Constructors
	public TrainCompany() {
		this.companyName = "Unknown Company";
		this.trains = new ArrayList<>();
	}

	// Constructor with fields
	public TrainCompany(String companyName, List<PassengerTrain> trains) {
		this.companyName = companyName;
		this.trains = trains != null ? trains : new ArrayList<>();
		nbOfTrains += this.trains.size();
	}

	// DeepCopy constructor
	public TrainCompany(TrainCompany original) throws CloneNotSupportedException {
		this.companyName = original.companyName;
		this.trains = new ArrayList<>();
		for (PassengerTrain t : original.trains) {
			this.trains.add(t.clone()); 
		}
	}
}
