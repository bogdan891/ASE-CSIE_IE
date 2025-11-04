package dice.ase.ro;

import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.TreeMap;
import java.util.TreeSet;

public class ProgMain {

	public static List<MobilePhone> readPhoneList(String fileName){
		List<MobilePhone> phones = new ArrayList<>();
		try(DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream("phones.txt")))){
			while(dis.available() > 0) {
				MobilePhone mp = new MobilePhone();
				mp.setModel(dis.readUTF());
				mp.setManufacturer(dis.readUTF());
				mp.setPrice(dis.readDouble());
				mp.setIs5G(dis.readBoolean());
				mp.setBatteryLevel(dis.readInt());
				phones.add(mp);
			}
		} catch(IOException e){
			e.printStackTrace();
		}
		return phones;
	}
	
	public static void main(String[] args) {
		MobilePhone m1 = new MobilePhone("iPhone 14 Pro", "Apple", 6499.99, 10, true);
		MobilePhone m2 = new MobilePhone("Galaxy S25 Ultra", "Samsung", 6999.49, 95, true);
		MobilePhone m3 = new MobilePhone("Pixel 8", "Google", 4799.00, 88, true);
		MobilePhone m4 = new MobilePhone("Xiaomi 13 Pro", "Xiaomi", 3599.89, 60, true);
		MobilePhone m5 = new MobilePhone("Nokia 3310", "Nokia", 199.99, 100, false);
		
		//Initializare lista
		List<MobilePhone> phones = Arrays.asList(m1, m2, m3, m4, m5);
		m2.chargePhone(2);
		
		//Afisare elemente
		System.out.println("My mobile phones:");
		for(MobilePhone x : phones) {
			System.out.println(x);
		}

		//Afisare Elemente sortate dupa pret
		List<MobilePhone> sortedPhones = phones.stream()
			    .sorted((p1, p2) -> {
			        int cmp = Double.compare(p1.getPrice(), p2.getPrice());
			        return cmp != 0 ? cmp : Integer.compare(p2.getBatteryLevel(), p1.getBatteryLevel());
			    })
			    .toList();
		System.out.println();
		System.out.println("Sorted mobile phones by price and battery level:");
		sortedPhones.forEach(m -> System.out.println(m));
		
		//Salvare lista in fisier -> serializare
		//sortedPhones.forEach(m -> m.SaveMobilePhone2File());
		
		//Citire din fisier -> deserializare
		List<MobilePhone> readPhones = readPhoneList("phones.txt");
		System.out.println();
		System.out.println("Phones read from file:");;
		readPhones.forEach(m -> System.out.println(m));
		
		//Set
		Set<MobilePhone> set = new HashSet<>();
		set.add(new MobilePhone("iPhone", "Apple", 5000, 80, true));
		set.add(new MobilePhone("Samsung", "Samsung", 4800, 90, true));
		set.add(new MobilePhone("iPhone", "Apple", 5000, 80, true));

		System.out.println("HashSet (fără ordine):");
		for (MobilePhone m : set) {
		    System.out.println(m);
		}
		
		//TreeSet
		TreeSet<MobilePhone> tree = new TreeSet<>(
			    Comparator.comparingDouble(MobilePhone::getPrice)
			              .thenComparingInt(MobilePhone::getBatteryLevel)
			);
		tree.add(new MobilePhone("Xiaomi", "Xiaomi", 3000, 70, true));
		tree.add(new MobilePhone("Pixel", "Google", 4500, 60, true));
		tree.add(new MobilePhone("Samsung", "Samsung", 4800, 80, true));

		System.out.println("\nTreeSet (sortat):");
		for (MobilePhone m : tree) {
		    System.out.println(m);
		}
		
		//HashMap
		Map<String, MobilePhone> phoneMap = new HashMap<>();
		phoneMap.put("M1", new MobilePhone("iPhone", "Apple", 5000, 80, true));
		phoneMap.put("M2", new MobilePhone("Pixel", "Google", 4800, 85, true));

		System.out.println("\nHashMap:");
		for (Map.Entry<String, MobilePhone> entry : phoneMap.entrySet()) {
		    System.out.println(entry.getKey() + " → " + entry.getValue());
		}
		
		//TreeMap
		TreeMap<MobilePhone, String> treeMap = new TreeMap<>(
			    Comparator.comparingDouble(MobilePhone::getPrice)
			              .thenComparingInt(MobilePhone::getBatteryLevel)
			);
		treeMap.put(new MobilePhone("Galaxy", "Samsung", 4000, 85, true), "Samsung");
		treeMap.put(new MobilePhone("iPhone", "Apple", 5000, 90, true), "Apple");

		System.out.println("\nTreeMap (Sorted keys):");
		treeMap.forEach((k, v) -> System.out.println(k + " → " + v));

	}
}
