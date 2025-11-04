package csie.ase.server;

import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

import java.nio.file.Files;
import java.nio.file.Path;

public class Client {

	public static void main(String[] args) {
		final int port = 9990;
		final String filePath = "airplanes.bin";

		try (Socket socket = new Socket("localhost", port);
		     DataOutputStream dos = new DataOutputStream(socket.getOutputStream())) {

			byte[] fileBytes = Files.readAllBytes(Path.of(filePath));
			dos.writeInt(fileBytes.length); // trimite întâi lungimea
			dos.write(fileBytes); // apoi conținutul fișierului

			System.out.println("[CLIENT] Sent file 'airplanes.bin' to server (" + fileBytes.length + " bytes).");

		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
