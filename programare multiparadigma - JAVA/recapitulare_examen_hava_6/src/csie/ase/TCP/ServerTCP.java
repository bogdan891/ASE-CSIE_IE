package csie.ase.TCP;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.List;

import csie.ase.classes.*;
import csie.ase.utils.*;

public class ServerTCP {
	public static void main(String[] args) {
		int portSerial = 8359;
		try (ServerSocket serverSocket = new ServerSocket(portSerial)){
			System.out.println("The server is ready to connect!");
			while(true) {
				Socket clientSocket = serverSocket.accept();
				  List<Bus> buses = Deserialize.deserializeFromServer(clientSocket);
	                if(buses != null) {
	                	buses.forEach(System.out::println);
	                }
	              
	                TxtFile.saveBusList2File(buses, "bus.txt");
                    Serialize.serialize2Server(buses, clientSocket);
			}
			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
