package csie.ase.utils;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import csie.ase.classes.Bus;

public class TxtFile {
	public static void saveBusList2File(List<Bus> buses, String fileName) {
		try (BufferedWriter out = new BufferedWriter(new FileWriter(fileName, true))) {
			for (Bus x : buses) {
				out.write(CSV.toCSV(x));
				out.newLine();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public static List<Bus> readBusListFormFile(String fileName){
		List<Bus> buses = new ArrayList<>();
		try (BufferedReader in = new BufferedReader(new FileReader(fileName))) {
			String line;
		        while ((line = in.readLine()) != null) {
		            if (!line.trim().isEmpty()) {
		                Bus b = CSV.fromCSV(line);
		                buses.add(b);
		            }
		        }
		} catch(IOException e){
			e.printStackTrace();
		}
		return buses;
	}
}
