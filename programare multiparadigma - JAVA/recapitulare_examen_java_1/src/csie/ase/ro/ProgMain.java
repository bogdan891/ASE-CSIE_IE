package csie.ase.ro;

import java.util.Arrays;
import java.util.Collections;
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
		PassengerTrain t1 = new PassengerTrain(10, 160.0f, "IR1981", "București Nord - Cluj Napoca", new int[]{72, 72, 72, 72, 68, 68, 68, 68, 60, 60});
		PassengerTrain t2 = new PassengerTrain(8, 140.0f, "IC552", "Constanța - București Nord", new int[]{80, 80, 80, 76, 76, 70, 70, 68});
		PassengerTrain t3 = new PassengerTrain(6, 120.0f, "R-E9214", "Iași - Pașcani", new int[]{64, 64, 64, 60, 60, 60});
		PassengerTrain t4 = new PassengerTrain(9, 160.0f, "IR1753", "Timișoara Nord - București Nord", new int[]{74, 74, 70, 70, 68, 68, 68, 64, 64});
		PassengerTrain t5 = new PassengerTrain(7, 130.0f, "R4062", "Brașov - Sfântu Gheorghe", new int[]{60, 60, 60, 56, 56, 56, 56});
		PassengerTrain t6 = new PassengerTrain(5, 100.0f, "R3001", "Pitești - Curtea de Argeș", new int[]{50, 50, 50, 48, 48});
		PassengerTrain t7 = new PassengerTrain(12, 200.0f, "ICN794", "București Nord - Viena", new int[]{70, 70, 70, 68, 68, 68, 68, 66, 66, 64, 64, 64});
		
		List<PassengerTrain> trains = Arrays.asList(t1,t2,t3,t4,t5,t6,t7);
		System.out.println("The elements of trains list:");
		trains.forEach(t -> System.out.println(t));
		
		System.out.println();
		System.out.println("Sorted trains:");
		Collections.sort(trains);
		trains.forEach(t -> System.out.println(t));
		
		//Set
		Set<PassengerTrain> trainTreeSet = new TreeSet<>();
		trains.forEach(t -> trainTreeSet.add(t));
		System.out.println();
		System.out.println("The elements of TreeSet");
		for(Iterator<PassengerTrain> it = trainTreeSet.iterator(); it.hasNext();) {
			PassengerTrain train = it.next();
			System.out.println(train);
		}
		
		Set<PassengerTrain> trainHashSet = new HashSet<>();
		trains.forEach(t -> trainHashSet.add(t));
		System.out.println();
		System.out.println("The elements of HashSet");
		for(Iterator<PassengerTrain> it = trainHashSet.iterator(); it.hasNext();) {
			PassengerTrain train = it.next();
			System.out.println(train);
		}
		
		//Map
		Map<String, PassengerTrain> treeMap = new TreeMap<>();
		treeMap.put("IR1981", new PassengerTrain(10, 160.0f, "IR1981", "București Nord - Cluj Napoca", new int[]{72, 72, 72, 72, 68, 68, 68, 68, 60, 60}));
		treeMap.put("IC552", new PassengerTrain(8, 140.0f, "IC552", "Constanța - București Nord", new int[]{80, 80, 80, 76, 76, 70, 70, 68}));
		treeMap.put("R-E9214", new PassengerTrain(6, 120.0f, "R-E9214", "Iași - Pașcani", new int[]{64, 64, 64, 60, 60, 60}));
		treeMap.put("IR1753", new PassengerTrain(9, 160.0f, "IR1753", "Timișoara Nord - București Nord", new int[]{74, 74, 70, 70, 68, 68, 68, 64, 64}));
		treeMap.put("R4062", new PassengerTrain(7, 130.0f, "R4062", "Brașov - Sfântu Gheorghe", new int[]{60, 60, 60, 56, 56, 56, 56}));
		treeMap.put("R3001", new PassengerTrain(5, 100.0f, "R3001", "Pitești - Curtea de Argeș", new int[]{50, 50, 50, 48, 48}));
		treeMap.put("ICN794", new PassengerTrain(12, 200.0f, "ICN794", "București Nord - Viena", new int[]{70, 70, 70, 68, 68, 68, 68, 66, 66, 64, 64, 64}));
		System.out.println("\nTreeMap (Sorted keys):");
		treeMap.forEach((k, v) -> System.out.println(k + " → " + v));
		
		Map<String, PassengerTrain> hashMap = new HashMap<>();
		hashMap.put("IR1981", new PassengerTrain(10, 160.0f, "IR1981", "București Nord - Cluj Napoca", new int[]{72, 72, 72, 72, 68, 68, 68, 68, 60, 60}));
		hashMap.put("IC552", new PassengerTrain(8, 140.0f, "IC552", "Constanța - București Nord", new int[]{80, 80, 80, 76, 76, 70, 70, 68}));
		hashMap.put("R-E9214", new PassengerTrain(6, 120.0f, "R-E9214", "Iași - Pașcani", new int[]{64, 64, 64, 60, 60, 60}));
		hashMap.put("IR1753", new PassengerTrain(9, 160.0f, "IR1753", "Timișoara Nord - București Nord", new int[]{74, 74, 70, 70, 68, 68, 68, 64, 64}));
		hashMap.put("R4062", new PassengerTrain(7, 130.0f, "R4062", "Brașov - Sfântu Gheorghe", new int[]{60, 60, 60, 56, 56, 56, 56}));
		hashMap.put("R3001", new PassengerTrain(5, 100.0f, "R3001", "Pitești - Curtea de Argeș", new int[]{50, 50, 50, 48, 48}));
		hashMap.put("ICN794", new PassengerTrain(12, 200.0f, "ICN794", "București Nord - Viena", new int[]{70, 70, 70, 68, 68, 68, 68, 66, 66, 64, 64, 64}));
		
		System.out.println("\nHashMap:");
		for(Map.Entry<String, PassengerTrain> entry : hashMap.entrySet()) {
			System.out.println(entry.getKey() + "->" + entry.getValue());
		}
	}

}
