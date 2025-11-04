package csie.ase.server;

import java.io.FileOutputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;

import csie.ase.classes.Car;
import csie.ase.classes.CarExpense;

public class ClientTCP {
	public static void main(String[] args) {
		try {
			// === Pregătire obiecte și scriere în fișiere binare ===
			List<CarExpense> expenses1 = new ArrayList<>();
			expenses1.add(new CarExpense("fuel", 300));
			expenses1.add(new CarExpense("insurance", 500));
			Car car1 = new Car("B-101-XYZ", "Allianz", expenses1);
			car1.setDistanceKm(200);
			car1.setGasConsumption(15);

			List<CarExpense> expenses2 = new ArrayList<>();
			expenses2.add(new CarExpense("parking", 150));
			Car car2 = new Car("B-202-ABC", "Groupama", expenses2);
			car2.setDistanceKm(150);
			car2.setGasConsumption(10);

			List<Car> cars1 = new ArrayList<>();
			cars1.add(car1);
			List<Car> cars2 = new ArrayList<>();
			cars2.add(car2);

			// Salvare locală în fișiere binare
			try (ObjectOutputStream oos1 = new ObjectOutputStream(new FileOutputStream("cars1.bin"));
				 ObjectOutputStream oos2 = new ObjectOutputStream(new FileOutputStream("cars2.bin"))) {
				oos1.writeObject(cars1);
				oos2.writeObject(cars2);
			}

			// === Trimite fișierele binare ca byte[] prin TCP ===
			try (Socket socket = new Socket("localhost", 9811);
			     ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream())) {

				byte[] file1 = Files.readAllBytes(Path.of("cars1.bin"));
				byte[] file2 = Files.readAllBytes(Path.of("cars2.bin"));

				out.writeObject(file1);
				out.writeObject(file2);
				out.flush();

				System.out.println("[CLIENT] Sent files cars1.bin and cars2.bin to server.");
			}

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
