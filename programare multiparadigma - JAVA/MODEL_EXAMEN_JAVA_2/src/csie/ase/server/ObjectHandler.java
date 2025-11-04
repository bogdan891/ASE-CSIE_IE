package csie.ase.server;

import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.net.Socket;

public class ObjectHandler implements Runnable {
	private Socket socket;

	public ObjectHandler(Socket socket) {
		this.socket = socket;
	}

	@Override
	public void run() {
		try (ObjectInputStream ois = new ObjectInputStream(socket.getInputStream())) {
			// === Primire fisier 1 ===
			byte[] file1 = (byte[]) ois.readObject();
			try (FileOutputStream fos = new FileOutputStream("received_cars1.bin")) {
				fos.write(file1);
			}
			System.out.println("[SERVER] Received and saved received_cars1.bin");

			// === Primire fisier 2 ===
			byte[] file2 = (byte[]) ois.readObject();
			try (FileOutputStream fos = new FileOutputStream("received_cars2.bin")) {
				fos.write(file2);
			}
			System.out.println("[SERVER] Received and saved received_cars2.bin");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
