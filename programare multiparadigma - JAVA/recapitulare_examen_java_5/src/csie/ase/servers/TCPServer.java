package csie.ase.servers;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

import csie.ase.ro.classes.*;

public class TCPServer {
	public static void main(String[] args) {
		int portSerial = 8339;
		try(ServerSocket serverSocket = new ServerSocket(portSerial)){
			System.out.println("The server is ready to connect!");
			while(true) {
				Socket clientSocket = serverSocket.accept();
				new Thread(new MobilePhoneHandler(clientSocket)).start();
			}
			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
