package eu.ase.httpserver;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class HTTPMultiServer {

	public static void main(String[] args) {
		try {
			ServerSocket serverSocket = new ServerSocket(8883);
			System.out.println("Server listens on port 8883");
			
			while(true) {
				Socket client = serverSocket.accept();
				HTTPMultiServerThread objClient = new HTTPMultiServerThread(client);
				objClient.start();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
