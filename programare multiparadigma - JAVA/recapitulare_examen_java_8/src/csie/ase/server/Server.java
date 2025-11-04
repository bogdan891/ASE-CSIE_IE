package csie.ase.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import csie.ase.classes.*;

public class Server {
	public static void main(String[] args) {
		final int port = 9890;
		final List<Car> cars = Collections.synchronizedList(new ArrayList<>());
		
		ExecutorService executor = Executors.newFixedThreadPool(4);
		try(ServerSocket socket = new ServerSocket(port)){
			System.out.println("[SERVER] connect on port " + port);
			while(true) {
				Socket clientSocket = socket.accept();
				executor.execute(new CarHandler(clientSocket, cars));
			}
		} catch(IOException e) {
			e.printStackTrace();
		}
	}
	
}
