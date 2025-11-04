package csie.ase.clients;

import java.io.IOException;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import csie.ase.functions.Deserialize4Server;
import csie.ase.functions.Serialize4Server;
import csie.ase.ro.classes.*;

public class TCPClient {
	public static void main(String[] args) {
		try {
			Socket clientSocket = new Socket("localhost", 8339);
			MobilePhone m1 = new MobilePhone("iPhone 14 Pro", "Apple", 6499.99, 10, true);
			MobilePhone m2 = new MobilePhone("Galaxy S25 Ultra", "Samsung", 6999.49, 95, true);
			MobilePhone m3 = new MobilePhone("Pixel 8", "Google", 4799.00, 88, true);
			MobilePhone m4 = new MobilePhone("Xiaomi 13 Pro", "Xiaomi", 3599.89, 60, true);
			MobilePhone m5 = new MobilePhone("Nokia 3310", "Nokia", 199.99, 100, false);
			
			//Initializare lista
			List<MobilePhone> phones = new ArrayList<>(Arrays.asList(m1, m2, m3, m4, m5));			
			Serialize4Server.serializeMobilePhoneList(phones, clientSocket);
			
			//Primire lista modificata
			List<MobilePhone> receivedList = Deserialize4Server.deserializeListFromServer(clientSocket);
			System.out.println("The list received by client:");
			receivedList.forEach(System.out::println);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
