package eu.ase.poly;


// Create the Vehicle class which implements Movement and Cloneable interface 
// and is has a private int non-static field weight with default constructor and constructor with 
// one parameter, plus get and set methods
// implement public String display() method for returning a string which contain the Vehicle weight
public class Vehicle implements Movement, Cloneable {
	private int weight;

	public Vehicle(int weight) {
		this.weight = weight;
	}
	
	public Vehicle() {
		this.weight = 0;
	}

	public int getWeight() {
		return weight;
	}

	public void setWeight(int weight) {
		this.weight = weight;
	}

	public String display() {
		return "weight: " + this.weight;
	}

	public Vehicle clone() throws CloneNotSupportedException {
        Vehicle cloned = (Vehicle) super.clone();
        cloned.weight = this.weight;
        return cloned;
    }

	@Override
	public void startEngine() {
		// TODO Auto-generated method stub
		
	}
}
