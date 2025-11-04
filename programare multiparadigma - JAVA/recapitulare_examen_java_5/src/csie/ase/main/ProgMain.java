package csie.ase.main;

import java.util.Collections;
import java.util.List;

import csie.ase.ro.classes.*;
import csie.ase.functions.*;

public class ProgMain {
	public static void main(String[] args) {
		//Initializare lista
		List<MobilePhone> phones = ReadFromFile.readMobilePhoneListFromTextFile("phones.txt");
		Collections.sort(phones);
		phones.forEach(System.out::println);
		//Save2File.saveListToTextFile(phones, "phones.txt");
		
	}
}
