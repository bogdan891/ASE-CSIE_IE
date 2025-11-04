package csie.ase.ro;

public abstract class Train implements Cloneable, MyComparable<Train>{
	private int nbOfCoaches;
	private float maxSpeed;
	
	//Getters & Setters
	public int getNbOfCoaches() {
		return nbOfCoaches;
	}
	
	public void setNbOfCoaches(int nbOfCoaches) {
		if(nbOfCoaches > 0) {
			this.nbOfCoaches = nbOfCoaches;
		} else {
			throw new IllegalArgumentException("The number of coaches of the train must be greater then 0!");
		}
	}
	
	public float getMaxSpeed() {
		return maxSpeed;
	}
	
	public void setMaxSpeed(float maxSpeed) {
		if(maxSpeed > 0) {
			this.maxSpeed = maxSpeed;
		} else {
			throw new IllegalArgumentException("The max speed of the train must be greater then 0!");
		}
	}
	
	//Constructors
	public Train() {
		this.nbOfCoaches = 0;
		this.maxSpeed = 0.2f;
	}
	
	public Train(int nbOfCoaches, float maxSpeed) {
		this.nbOfCoaches = nbOfCoaches;
		this.maxSpeed = maxSpeed;
	}
	
	//Override / Implements methods

	@Override
	public int hashCode() {
	    int result = Integer.hashCode(nbOfCoaches);
	    result = 31 * result + Float.hashCode(maxSpeed);
	    return result;
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(!(obj instanceof Train)) return false;
		if(obj == null || getClass() != obj.getClass()) return false;
		Train t = (Train) obj;
		if(this.getNbOfCoaches() == t.getNbOfCoaches() && this.getMaxSpeed() == t.getMaxSpeed())
			return true;
		return false;
	}

	@Override
	public abstract Train clone() throws CloneNotSupportedException;

	@Override
	public String toString() {
		return "Train - number of coaches " + this.getNbOfCoaches() + " - max speed " + this.getMaxSpeed() + "km/h";	
	}
	
	@Override 
	public int compareTo(Train other) {
		return Float.compare(this.getMaxSpeed(), other.getMaxSpeed());
	}
}
