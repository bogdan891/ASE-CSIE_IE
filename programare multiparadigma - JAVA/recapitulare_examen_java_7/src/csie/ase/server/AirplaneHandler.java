package csie.ase.server;

import java.io.ByteArrayInputStream;
import java.io.DataInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.Socket;
import java.util.Collections;
import java.util.List;

import csie.ase.classes.Airplane;

public class AirplaneHandler implements Runnable{
	private Socket socket;
	private List<Airplane> airplaneList;

	public AirplaneHandler(Socket socket, List<Airplane> airplaneList) {
		super();
		this.socket = socket;
		this.airplaneList = airplaneList;
		
	}
	
	@Override
	public void run() {
		try {
			DataInputStream in = new DataInputStream(socket.getInputStream());
			int length = in.readInt();
			byte[] buffer = new byte[length];
			in.readFully(buffer);
			
			try (ObjectInputStream ois = new ObjectInputStream(new ByteArrayInputStream(buffer))) {
				Airplane airplane = (Airplane) ois.readObject();

				synchronized (airplaneList) {
					airplaneList.add(airplane);
				}

			Collections.sort(airplaneList, Collections.reverseOrder());
			System.out.println("The content of received file:");
			airplaneList.forEach(System.out::println);
			
		} catch (IOException | ClassNotFoundException e) {
			e.printStackTrace();
		}
			
		} catch(IOException e) {
			e.printStackTrace();
		}
	}
}
