package csie.ase.ro.classes;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class TCPServer {
	public static void main(String[] args) {
		try (ServerSocket serverSocket = new ServerSocket(8333)) {
			System.out.println("The server is waiting for a connection!");
			while(true) {
				Socket clientSocket = serverSocket.accept();
				new Thread(new SeriesHandler(clientSocket)).start();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}	
	}
}
