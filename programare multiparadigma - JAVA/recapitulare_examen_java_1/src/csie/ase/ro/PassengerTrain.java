package csie.ase.ro;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.Serializable;
import java.util.Arrays;
import java.util.Objects;

public class PassengerTrain extends Train implements Comparable<PassengerTrain>, Cloneable, Serializable{
	private static final long serialVersionUID = 1L;
	private String name;
	private String route;
	private int[] seatsPerCoach;
	
	
	//Getters & Setters
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public String getRoute() {
		return route;
	}
	
	public void setRoute(String route) {
		this.route = route;
	}
	
	public int[] getSeatsPerCoach() {
		if (this.seatsPerCoach != null) {
			return Arrays.copyOf(this.seatsPerCoach, this.getNbOfCoaches());
		}
		return null;
	}
	
	public void setSeatsPerCoach(int[] seatsPerCoach, int nbOfCoaches) {
		if (seatsPerCoach != null && nbOfCoaches > 0) {
			this.seatsPerCoach = Arrays.copyOf(seatsPerCoach, nbOfCoaches);
		} else {
			this.seatsPerCoach = null;
		}
	}
	
	//Constructors
	public PassengerTrain() {
		super();
		this.name = "Unknown";
		this.route = "Unknown";
		this.seatsPerCoach = null;
	}

	public PassengerTrain(int nbOfCoaches, float maxSpeed, String name, String route, int[] seatsPerCoach) {
		super(nbOfCoaches, maxSpeed);
		this.name = name;
		this.route = route;
		if(seatsPerCoach != null && nbOfCoaches > 0) {
			this.seatsPerCoach = new int[nbOfCoaches];
			for(int i=0; i < nbOfCoaches; i++) {
				this.seatsPerCoach[i] = seatsPerCoach[i];
			}
		} else {
			this.seatsPerCoach = null;
		}
	}
	
	//Override / Implements methods
	@Override
	public int hashCode() {
		return Objects.hash(super.hashCode(), name, route, Arrays.hashCode(seatsPerCoach));
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(!(obj instanceof PassengerTrain)) return false;
		if(!super.equals(obj)) return false;
		 PassengerTrain t = (PassengerTrain) obj;

		 return this.getName().equals(t.getName())
			        && this.getRoute().equals(t.getRoute())
			        && Arrays.equals(this.seatsPerCoach, t.seatsPerCoach);
		}

	@Override
	public PassengerTrain clone() throws CloneNotSupportedException {
		return new PassengerTrain(this.getNbOfCoaches(), this.getMaxSpeed(), this.getName(), this.getRoute(), this.getSeatsPerCoach());
	}

	@Override
	public String toString() {
		return "Train " + this.getName() + ", Route: " + this.getRoute() + ", max speed: " + this.getMaxSpeed() + "km/h";
	}

	@Override
	public int compareTo(PassengerTrain other) {
		return Float.compare(this.getMaxSpeed(), other.getMaxSpeed());
	}
	
	public void SerializePassengerTrain(String fileName) {
		boolean append = true;
		try(DataOutputStream dos = new DataOutputStream(new BufferedOutputStream(new FileOutputStream(fileName, append)))){
			
			dos.writeInt(this.getNbOfCoaches());
			dos.writeFloat(this.getMaxSpeed());

			dos.writeUTF(this.getName() != null ? this.getName() : "");  
			dos.writeUTF(this.getRoute() != null ? this.getRoute() : "");
			
			if (this.getSeatsPerCoach() != null) {
				dos.writeBoolean(true);
				dos.writeInt(this.getSeatsPerCoach().length);
				for (int seat : this.getSeatsPerCoach()) {
					dos.writeInt(seat);
				}
			} else {
				dos.writeBoolean(false);
			}
		} catch(IOException e) {
			e.printStackTrace();
		}
	}
	
	public PassengerTrain DeserializePassengerTrain(String fileName) {
		try (DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream(fileName)))) {
			
			int nbOfCoaches = dis.readInt();
			float maxSpeed = dis.readFloat();

			String name = dis.readUTF();
			String route = dis.readUTF();

			int[] seatsPerCoach = null;
			boolean hasArray = dis.readBoolean();
			if (hasArray) {
				int length = dis.readInt();
				seatsPerCoach = new int[length];
				for (int i = 0; i < length; i++) {
					seatsPerCoach[i] = dis.readInt();
				}
			}
			
			return new PassengerTrain(nbOfCoaches, maxSpeed, name, route, seatsPerCoach);
		} catch (IOException e) {
			e.printStackTrace();
			return new PassengerTrain();
		}
	}
}
