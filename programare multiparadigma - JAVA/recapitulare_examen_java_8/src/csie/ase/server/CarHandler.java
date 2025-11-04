package csie.ase.server;

import java.io.ByteArrayInputStream;
import java.io.DataInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.Socket;
import java.util.Collections;
import java.util.List;

import csie.ase.classes.Car;

public class CarHandler implements Runnable{
	private Socket socket;
	private List<Car> cars; 
	
	public CarHandler(Socket socket, List<Car> cars) {
		super();
		this.socket = socket;
		this.cars = cars;
	}
	
	@Override
	public void run() {
		try {
			DataInputStream dis = new DataInputStream(socket.getInputStream());
			int length = dis.readInt();
			byte[] buffer = new byte[length];
			dis.readFully(buffer);
			
			ObjectInputStream ois = new ObjectInputStream(new ByteArrayInputStream(buffer));
			Car car = (Car) ois.readObject();
			
			synchronized (cars) {
				cars.add(car);
			}
			
			Collections.sort(cars, Collections.reverseOrder());
			System.out.println("The cars received from clients:");
			cars.forEach(System.out::println);
			
		} catch(IOException | ClassNotFoundException e) {
			e.printStackTrace();
		}
	}
}
