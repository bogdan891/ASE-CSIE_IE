package csie.ase.classes;

import java.io.Serializable;
import java.util.Arrays;
import java.util.Objects;

import csie.ase.utils.FuelType;

public class Bus extends Vehicle implements Cloneable, Serializable, Comparable<Bus> {
	private static final long serialVersionUID = 1L;
	String model;
	String route;
	int idRoute;
	int nbOfStops;
	float[] timeBetweenStops;
	
	//Constructors
	public Bus() {
		super();
		this.model = "N/A";
		this.route = "N/A";
		this.idRoute = 0;
		this.nbOfStops = 0;
		this.timeBetweenStops = null;
	}
	
	public Bus(String manufacturer, String plate, FuelType engineFuel, String model, String route, int idRoute, int nbOfStops, float[] timeBetweenStops) {
		super(manufacturer, plate, engineFuel);
		this.model = model;
		this.route = route;
		this.idRoute = idRoute;
		this.nbOfStops = nbOfStops;
		if(timeBetweenStops != null && nbOfStops > 0) {
			this.timeBetweenStops = Arrays.copyOf(timeBetweenStops, nbOfStops);
		} else {
			this.timeBetweenStops = null;
		}
	}
	
	//Getters & Setters
	public String getModel() {
		return model;
	}

	public void setModel(String model) {
		this.model = model;
	}

	public String getRoute() {
		return route;
	}

	public void setRoute(String route) {
		this.route = route;
	}

	public int getIdRoute() {
		return idRoute;
	}

	public void setIdRoute(int idRoute) {
		if(idRoute >= 100 && idRoute <= 799) {
			this.idRoute = idRoute;
		} else {
			throw new IllegalArgumentException("The idRoute must be between 100 and 799!");
		}
	}

	public int getNbOfStops() {
		return nbOfStops;
	}

	public void setNbOfStops(int nbOfStops) {
		if(nbOfStops > 0) {
			this.nbOfStops = nbOfStops;
		} else {
			throw new IllegalArgumentException("The number of stops must be greater then 0!");
		}
	}

	public float[] getTimeBetweenStops() {
		return Arrays.copyOf(timeBetweenStops, nbOfStops);
	}

	public void setTimeBetweenStops(float[] timeBetweenStops, int nbOfStops) {
		if(timeBetweenStops != null && nbOfStops > 0) {
			this.timeBetweenStops = Arrays.copyOf(timeBetweenStops, nbOfStops);
		} else {
			this.timeBetweenStops = null;
		}
	}
	
	//Override or implements methods

	@Override
	public int compareTo(Bus o) {
		return Integer.compare(idRoute, o.idRoute);
	}

	@Override
	public int hashCode() {
		return Objects.hash(super.hashCode(), this.getModel(), this.getRoute(), this.getIdRoute(), this.getNbOfStops(), this.getTimeBetweenStops());
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || this.getClass() != obj.getClass()) return false;
		if(!super.equals(obj)) return false;
		Bus bus = (Bus) obj;
		return this.getModel().equals(bus.getModel()) && this.getRoute().equals(bus.getRoute())
				&& Integer.compare(this.getIdRoute(), bus.getIdRoute()) == 0 && Integer.compare(this.getNbOfStops(), bus.getNbOfStops()) == 0
				&& Arrays.compare(this.getTimeBetweenStops(), bus.getTimeBetweenStops()) == 0;
	}

	@Override
	protected Vehicle clone() throws CloneNotSupportedException {
		return new Bus(this.getManufacturer(), this.getPlate(), this.getEngineFuel(), this.getModel(), this.getRoute(),
				this.getIdRoute(), this.getNbOfStops(), this.getTimeBetweenStops());
	}

	@Override
	public String toString() {
		return this.getIdRoute() + " " + this.getRoute() + " " + ", Bus: " + this.getManufacturer() + " " + this.getModel();
	}
}
