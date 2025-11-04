package eu.ase.poly;

import static org.junit.Assert.assertThrows;

// Create the Auto class which is inheriting Vehicle and it is adding the following private fields:
// - doorsNo: int
// - noCars: int static
// - Create default constructor and constructor with parameters
// - create get/set methods with eventual throw Exception statement
// - overwrite display method from Vehicle class and close (AutoCloseable interface) and clone (Cloneable interface) methods
public class Auto extends Vehicle implements AutoCloseable, Cloneable {
	private int doorsNo;
	private static int noCars;
	
	public Auto() {
		this.doorsNo = 0;
		this.noCars = 0;
	}
	
	public Auto(int weight, int doorsNo, int noCars) {
		super(weight);
		this.doorsNo = doorsNo;
		this.noCars = noCars;
	}

	public Auto(int doorsNo, int noCars) {
		this.doorsNo = doorsNo;
		this.noCars = noCars;
	}

	public int getDoorsNo() {
		return doorsNo;
	}

	public void setDoorsNo(int doorsNo) {
		 if (doorsNo > 0) {
		        this.doorsNo = doorsNo;
		    } else {
		        throw new IllegalArgumentException("doorsNo cannot be negative!");
		    }
	}

	public static int getNoCars() {
		return noCars;
	}

	public void setNoCars(int noCars) {
		this.noCars = noCars;
	}
	
	@Override
	public String display() {
		return "Number of doors: " + this.doorsNo + ", Number of cars: " + this.noCars;
	}

	@Override
	public Auto clone() throws CloneNotSupportedException {
        Auto cloned = (Auto) super.clone();
        cloned.doorsNo = this.doorsNo; 
        cloned.noCars = this.noCars;
        return cloned;
    }

	@Override
	public void close() {
		// TODO Auto-generated method stub
		
	}
}
