package csie.ase.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Server {

	public static void main(String[] args) {
		final int port = 9990;
		ExecutorService executor = Executors.newFixedThreadPool(4);

		try (ServerSocket serverSocket = new ServerSocket(port)) {
			System.out.println("[SERVER] Listening on port " + port + "...");

			while (true) {
				Socket clientSocket = serverSocket.accept();
				System.out.println("[SERVER] Connected to client: " + clientSocket.getInetAddress());
				executor.execute(new AirPlaneHandler(clientSocket));
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
