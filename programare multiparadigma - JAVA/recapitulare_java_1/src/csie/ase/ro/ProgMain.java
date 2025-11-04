package csie.ase.ro;

import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.EOFException;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class ProgMain {

	public static void main(String[] args) throws IOException, CloneNotSupportedException {
		TrainRoute tr1 = new TrainRoute(1, "Bucharest", "Budapest", 600, 3, new float[] {2,2,2});
		TrainRoute tr2 = new TrainRoute(2, "Paris", "Lyon", 450.5f, 3, new float[] {1.5f, 2.0f, 1.0f});
		TrainRoute tr3 = new TrainRoute(3, "Berlin", "Munich", 600.0f, 4, new float[] {1.0f, 1.5f, 2.0f, 1.0f});
		TrainRoute tr4 = new TrainRoute(4, "Madrid", "Barcelona", 620.0f, 2, new float[] {2.5f, 3.0f});

		List<TrainRoute>trainList = new ArrayList<TrainRoute>();
		
		trainList.add(tr1); trainList.add(tr2); trainList.add(tr3); trainList.add(tr4);
		
		for (Iterator<TrainRoute> tr = trainList.iterator(); tr.hasNext();) {
			TrainRoute trTemp = tr.next();
			try {
				trTemp.saveFileTrainRoute("trains.txt");
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		
		List<TrainRoute> trains = new ArrayList<>();
		try (DataInputStream dis = new DataInputStream(
		        new BufferedInputStream(
		            new FileInputStream("trains.txt")))) {
		    while(true) {
		        TrainRoute t = TrainRoute.readFromFile("trains.txt");
		        trains.add(t);
		    }
		    

		}	catch (IOException e) {
		    	e.printStackTrace();
		}
		
		System.out.println("Train routes citite:");
		for (TrainRoute t : trains) {
		    System.out.println(t.toString());
		}
	}
}
