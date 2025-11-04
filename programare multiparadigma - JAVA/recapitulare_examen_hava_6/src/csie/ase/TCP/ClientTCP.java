package csie.ase.TCP;

import java.io.IOException;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

import csie.ase.classes.Bus;
import csie.ase.utils.Deserialize;
import csie.ase.utils.FuelType;
import csie.ase.utils.Serialize;

public class ClientTCP {

	public static void main(String[] args) {
		try {
			Socket clientSocket = new Socket("localhost", 8359);
			List<Bus> buses = new ArrayList<>();

			buses.add(new Bus("Mercedes", "B-123-STB", FuelType.DIESEL, "Citaro",
			        "Faur - Bucur Obor", 101, 6, new float[]{2.5f, 3.0f, 2.8f, 3.2f, 2.7f, 2.9f}));

			buses.add(new Bus("Otokar", "B-456-STB", FuelType.DIESEL, "Kent C",
			        "Piata Operei - Complex Pantelimon", 104, 5, new float[]{4.1f, 3.9f, 4.3f, 4.0f, 3.8f}));

			buses.add(new Bus("Mercedes", "B-789-STB", FuelType.HYBRID, "Citaro Hybrid",
			        "Sos. Nicolae Titulescu - Valea Oltului", 105, 4, new float[]{2.0f, 2.2f, 2.1f, 2.3f}));

			buses.add(new Bus("ZTE", "B-101-STB", FuelType.ELECTRIC, "Granton",
			        "Piata 21 Decembrie 1989 - Carrefour Militari", 137, 3, new float[]{3.5f, 3.8f, 3.9f}));
			
			Serialize.serialize2Server(buses, clientSocket);
			
			List<Bus> received = Deserialize.deserializeFromServer(clientSocket);
			if(received != null) {
				received.forEach(System.out::println);
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
