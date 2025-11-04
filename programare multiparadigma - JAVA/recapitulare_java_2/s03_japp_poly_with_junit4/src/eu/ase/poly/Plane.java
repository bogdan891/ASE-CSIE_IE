package eu.ase.poly;

//Create the Plane class which is inheriting Vehicle and it is adding the following private fields:
//- capacity: float
//- enginesNo: int
//- Create default constructor and constructor with parameters - using super
//- create get/set methods with eventual throw Exception statement
//- overwrite display method from Vehicle class
public class Plane extends Vehicle{
	private float capacity;
	private int enginesNo;
	
	public Plane() {
		super();
		this.capacity = 0;
		enginesNo = 0;
	}

	public Plane(int weight, float capacity, int enginesNo) {
		super(weight);
		this.capacity = capacity;
		this.enginesNo = enginesNo;
	}

	public float getCapacity() {
		return capacity;
	}

	public void setCapacity(float capacity) {
		if (capacity > 0) {
			this.capacity = capacity;
		} else {
			throw new IllegalArgumentException("Capacity must be positive!");
		}
	}

	public int getEnginesNo() {
		return enginesNo;
	}

	public void setEnginesNo(int enginesNo) {
		if (enginesNo > 0) {
			this.enginesNo = enginesNo;
		} else {
			throw new IllegalArgumentException("enginesNo must be positive!");
		}
	}
	
	@Override
	public String display() {
		return "Weight: " + this.getWeight() + ", Capacity: " + this.getCapacity() + ", Engines number: " + this.getEnginesNo();
	}
}
