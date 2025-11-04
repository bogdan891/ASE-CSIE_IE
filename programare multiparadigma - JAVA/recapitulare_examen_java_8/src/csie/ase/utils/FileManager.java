package csie.ase.utils;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.List;

import csie.ase.classes.Car;
import csie.ase.classes.CarExpense;

public class FileManager {
	public static void main(String[] args) {
		
		List<CarExpense> expenses1 = new ArrayList<>();
		expenses1.add(new CarExpense("gas_consumption", 15));
		expenses1.add(new CarExpense("gas_cost", 300));
		expenses1.add(new CarExpense("insurance_company", 500));
		expenses1.add(new CarExpense("parking_cost", 500));
		Car car1 = new Car(1001, "B-101-XYZ", "Allianz", 200, expenses1);
		
		List<CarExpense> expenses2 = new ArrayList<>();
		expenses1.add(new CarExpense("gas_consumption", 10));
		expenses1.add(new CarExpense("gas_cost", 300));
		expenses1.add(new CarExpense("insurance_company", 400));
		expenses1.add(new CarExpense("parking_cost", 500));
		Car car2 = new Car(1002, "B-202-ABC", "Groupama", 450, expenses2);

		try (ObjectOutputStream oos1 = new ObjectOutputStream(new FileOutputStream("cars1.bin"));
				 ObjectOutputStream oos2 = new ObjectOutputStream(new FileOutputStream("cars2.bin"))) {
				oos1.writeObject(car1);
				oos2.writeObject(car2);
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
	}
}
