package bogdan.csie.ase.ro;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.TreeMap;
import java.util.TreeSet;

public class ProgMain {
	public static void main(String[] args) {
		ClothesStore cs1 = new ClothesStore(
			    "Str. Victoriei 10, Bucuresti", "Andrei Popescu", 150.5, "UrbanStyle",
			    Products.Casual, 5, new float[]{199.99f, 249.99f, 179.50f});

			ClothesStore cs2 = new ClothesStore(
			    "Bd. Eroilor 45, Cluj-Napoca", "Maria Ionescu", 200.0, "CoolWear",
			    Products.Sport, 6, new float[]{299.99f, 349.99f});

			ClothesStore cs3 = new ClothesStore(
			    "Str. Libertatii 8, Brasov", "Radu Georgescu", 120.75, "MountainFit",
			    Products.Sport, 4, new float[]{89.99f, 59.99f, 79.99f});

			ClothesStore cs4 = new ClothesStore(
			    "Str. Dorobanti 27, Constanta", "Elena Dobre", 180.3, "SeaStyle",
			    Products.Elegant, 3, new float[]{499.99f, 389.99f, 444.50f});

			ClothesStore cs5 = new ClothesStore(
			    "Calea Timisorii 19, Timisoara", "Cristina Vasile", 160.0, "WestLook",
			    Products.Casual, 7, new float[]{229.99f, 209.50f});

			ClothesStore cs6 = new ClothesStore(
			    "Str. Stefan cel Mare 33, Iasi", "Ioan Muresan", 140.4, "ClassicFit",
			    Products.Elegant, 5, new float[]{319.99f, 289.99f, 299.00f});

			ClothesStore cs7 = new ClothesStore(
			    "Piata Centrala 1, Sibiu", "Ana Marin", 110.0, "CityTrends",
			    Products.Default, 2, new float[]{69.99f, 74.99f});
			
		List<ClothesStore> stores = Arrays.asList(cs1, cs2,cs3,cs4,cs5,cs6,cs7);
		
		//stores.forEach(x -> x.saveBinaryStore());
		System.out.println("The stores list:");
		List<ClothesStore> readStores = ClothesStore.readAllStores("stores.bin");
		readStores.forEach(System.out::println);
		
//		//Set
//		Set<ClothesStore> storeTreeSet = new TreeSet<>();
//		storeTreeSet.add(cs1);
//		storeTreeSet.add(cs2);
//		storeTreeSet.add(cs3);
//		storeTreeSet.add(cs4);
//		storeTreeSet.add(cs5);
//		storeTreeSet.add(cs6);
//		storeTreeSet.add(cs7);
//		System.out.println("\nThe stores TreeSet(sorted):");
//		storeTreeSet.forEach(System.out::println);
//		
//		Set<ClothesStore> storeHashSet = new HashSet<>();
//		storeHashSet.add(cs1);
//		storeHashSet.add(cs2);
//		storeHashSet.add(cs3);
//		storeHashSet.add(cs4);
//		storeHashSet.add(cs5);
//		storeHashSet.add(cs6);
//		storeHashSet.add(cs7);
//		
//		System.out.println("\nThe stores HashSet:");
//		for(Iterator<ClothesStore> it = storeHashSet.iterator(); it.hasNext();) {
//			ClothesStore x = it.next();
//			System.out.println(x);
//		}
//		
//		//Map
//		Map<String, ClothesStore> storeTreeMap = new TreeMap<>();
//		storeTreeMap.put("UrbanStyle", cs1);
//		storeTreeMap.put("CoolWear", cs2);
//		storeTreeMap.put("MountainFit", cs3);
//		storeTreeMap.put("SeaStyle", cs4);
//		storeTreeMap.put("WestLook", cs5);
//		storeTreeMap.put("ClassicFit", cs6);
//		storeTreeMap.put("CityTrends", cs7);
//		
//		System.out.println("\nThe stores TreeMap:");
//		storeTreeMap.forEach((k, v) -> System.out.println(k + " -> " + v));
//		
//		Map<String, ClothesStore> storeHashMap = new HashMap<>();
//		storeHashMap.put("UrbanStyle", cs1);
//		storeHashMap.put("CoolWear", cs2);
//		storeHashMap.put("MountainFit", cs3);
//		storeHashMap.put("SeaStyle", cs4);
//		storeHashMap.put("WestLook", cs5);
//		storeHashMap.put("ClassicFit", cs6);
//		storeHashMap.put("CityTrends", cs7);
//
//		System.out.println("\nThe stores HashMap:");
//		for(Map.Entry<String, ClothesStore> entry : storeHashMap.entrySet()) {
//			System.out.println(entry.getKey() + " -> " + entry.getValue());
//		}
	}

}
