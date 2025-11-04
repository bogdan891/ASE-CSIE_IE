package csie.ase.utils;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import csie.ase.classes.*;

public class WriteInFile {

	public static void main(String[] args) {
		 List<AirPlaneExpense> expenses1 = new ArrayList<>();
	        expenses1.add(new AirPlaneExpense("kerosene_cost", 800));
	        expenses1.add(new AirPlaneExpense("insurance_cost", 500));
	        expenses1.add(new AirPlaneExpense("flightcrew_cost", 400));

	        List<AirPlaneExpense> expenses2 = new ArrayList<>();
	        expenses2.add(new AirPlaneExpense("kerosene_cost", 700));
	        expenses2.add(new AirPlaneExpense("insurance_cost", 400));
	        expenses2.add(new AirPlaneExpense("flightcrew_cost", 300));

	        List<AirPlane> airplanes = new ArrayList<>();
	        airplanes.add(new AirPlane(1, "Lufthansa", 1200, 6000, expenses1, LocalDate.now()));
	        airplanes.add(new AirPlane(2, "TAROM", 900, 4500, expenses2, LocalDate.now()));


	        try {
				IO.serialize(airplanes, new FileOutputStream("airplanes.bin", true));
			} catch (FileNotFoundException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
	        System.out.println("[APP] Serialized airplanes to file.");
	}

}
