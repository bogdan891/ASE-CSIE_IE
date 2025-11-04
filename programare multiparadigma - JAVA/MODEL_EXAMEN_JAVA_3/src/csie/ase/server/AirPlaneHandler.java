package csie.ase.server;

import java.io.DataInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.net.Socket;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Collections;
import java.util.List;

import csie.ase.classes.AirPlane;

public class AirPlaneHandler implements Runnable {
	private Socket socket;

	public AirPlaneHandler(Socket socket) {
		this.socket = socket;
	}

	@SuppressWarnings("unchecked")
	@Override
	public void run() {
		try (DataInputStream dis = new DataInputStream(socket.getInputStream())) {

			int length = dis.readInt(); // lungimea fișierului
			byte[] buffer = new byte[length];
			dis.readFully(buffer);

			// Salvează fișierul local
			String receivedFile = "received_airplanes.bin";
			try (FileOutputStream fos = new FileOutputStream(receivedFile)) {
				fos.write(buffer);
			}
			System.out.println("[SERVER] Saved file as '" + receivedFile + "'");

			// Deserializare din fișier
			List<AirPlane> planes;
			try (ObjectInputStream ois = new ObjectInputStream(Files.newInputStream(Paths.get(receivedFile)))) {
				Object obj = ois.readObject();
				if (obj instanceof List<?>) {
					planes = (List<AirPlane>) obj;
					System.out.println("[SERVER] Received and deserialized " + planes.size() + " airplanes.");
					Collections.sort(planes, Collections.reverseOrder());
					planes.forEach(System.out::println);
				} else {
					System.out.println("[SERVER] Invalid object received.");
				}
			}

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
