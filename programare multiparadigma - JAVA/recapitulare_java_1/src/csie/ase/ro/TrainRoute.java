package csie.ase.ro;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

public class TrainRoute implements Cloneable, Serializable{
	private int id;
	private String departure;
	private String arrival;
	private float distance;
	private int nbOfStops;
	private float[] timeBetweenStops;
	
	public TrainRoute(int id, String departure, String arrival, float distance, int nbOfStops, float[] timeBetweenStops) {
		this.id = id;
		this.departure = departure;
		this.arrival = arrival;
		this.distance = distance;
		this.nbOfStops = nbOfStops;
		this.timeBetweenStops = timeBetweenStops;
	}

	public TrainRoute() {
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getDeparture() {
		return departure;
	}

	public void setDeparture(String departure) {
		this.departure = departure;
	}

	public String getArrival() {
		return arrival;
	}

	public void setArrival(String arrival) {
		this.arrival = arrival;
	}

	public float getDistances() {
		return distance;
	}

	public void setDistances(float distances) {
		this.distance = distances;
	}

	public int getNbOfStops() {
		return nbOfStops;
	}

	public void setNbOfStops(int nbOfStops) {
		this.nbOfStops = nbOfStops;
	}

	public float[] getTimeBetweenStops() {
		return timeBetweenStops;
	}

	public void setTimeBetweenStops(float[] timeBetweenStops) {
		if (timeBetweenStops != null) {
			for (int i=0; i < this.getNbOfStops(); i++) {
				this.timeBetweenStops[i] = timeBetweenStops[i];
			}
		} else {
			this.timeBetweenStops = null;
		}
	}

	@Override
	public boolean equals(Object obj) {
		// TODO Auto-generated method stub
		return super.equals(obj);
	}

	@Override
	public TrainRoute clone() throws CloneNotSupportedException {
		TrainRoute copy = new TrainRoute();
		copy.id = id;
		copy.departure = departure;
		copy.arrival = arrival;
		copy.distance = distance;
		copy.nbOfStops = nbOfStops;
		if (nbOfStops > 0 && timeBetweenStops != null) {
			copy.timeBetweenStops = new float[copy.nbOfStops];
			for (int i = 0; i < copy.nbOfStops; i++) {
				copy.timeBetweenStops[i] = timeBetweenStops[i];
			}
		} else {
			copy.timeBetweenStops = null;
		}
		
		return	copy;
	}

	@Override
	public String toString() {
		String word = "Route id = " + this.id + ", Departure: " + this.departure + ", Arrival: " + this.arrival + ", Distance: "
				+ this.distance + ", Number of stops: " + this.nbOfStops + ".";
		return word;
	}
	
	public void saveFileTrainRoute(String fileName) throws IOException {
		DataOutputStream dos = null;
		try {
			FileOutputStream fos = new FileOutputStream(fileName, true);
			BufferedOutputStream bos = new BufferedOutputStream(fos);
			dos = new DataOutputStream(bos);
			dos.writeInt(this.getId());
			dos.writeUTF(this.getDeparture());
			dos.writeUTF(this.getArrival());
			dos.writeFloat(this.getDistances());
			dos.writeInt(this.getNbOfStops());
			if(this.getTimeBetweenStops() != null) {
				for(int i=0; i < this.getNbOfStops(); i++ ) {
					dos.writeFloat(this.getTimeBetweenStops()[i]);
					}
			} else {
				
			}
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} finally {
			dos.close();
		}
	}
	
		public static TrainRoute readFromFile(String fileName) {
			TrainRoute tr = new TrainRoute();
			DataInputStream dis = null;
			
			FileInputStream fis;
			try {
				fis = new FileInputStream(fileName);
				BufferedInputStream bis = new BufferedInputStream(fis);
				dis = new DataInputStream(bis);
				
				tr.setId(dis.readInt());
				tr.setDeparture(dis.readUTF());
				tr.setArrival(dis.readUTF());
				tr.setDistances(dis.readFloat());
				tr.setNbOfStops(dis.readInt());
				
				float[] temp = new float[tr.getNbOfStops()];
				for (int i=0; i < tr.getNbOfStops(); i++) {
					temp[i] = dis.readFloat();
				}
				tr.setTimeBetweenStops(temp);
				
			} catch (FileNotFoundException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			return tr;
		}
	}
