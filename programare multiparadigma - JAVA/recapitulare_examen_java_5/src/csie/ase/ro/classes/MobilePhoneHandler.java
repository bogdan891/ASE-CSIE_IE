package csie.ase.ro.classes;

import java.io.IOException;
import java.net.Socket;
import java.util.List;

import csie.ase.functions.*;

public class MobilePhoneHandler implements Runnable {
	private Socket clientSocket;

	public MobilePhoneHandler(Socket clientSocket) {
		this.clientSocket = clientSocket;
	}

	@Override
	public void run() {
		List<MobilePhone> receivedList = Deserialize4Server.deserializeListFromServer(clientSocket);
		System.out.println("The received list:");
		receivedList.forEach(System.out::println);
		receivedList.removeIf(x -> x.getPrice() < 4000);
		Serialize4Server.serializeMobilePhoneList(receivedList, clientSocket);
		try {
	        clientSocket.close();
	    } catch (IOException e) {
	        e.printStackTrace();
	    }
	}
}
