package csie.ase.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class ServerTCP {
	public static void main(String[] args) {
		try(ServerSocket socket = new ServerSocket(9811)){
			System.out.println("The server is starting on " + socket.getLocalPort());
			while(true) {
				Socket clientSocket = socket.accept();
				System.out.println("Connecting to ... " + clientSocket.getInetAddress());
				new Thread(new ObjectHandler(clientSocket)).start();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
