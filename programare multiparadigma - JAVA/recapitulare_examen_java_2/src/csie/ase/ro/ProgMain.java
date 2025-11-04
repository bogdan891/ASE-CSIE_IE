package csie.ase.ro;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.TreeMap;
import java.util.TreeSet;

public class ProgMain {

	public static void main(String[] args) {
		List<Series> myList = new ArrayList<>();
		myList.add(new Series("Breaking Bad", Category.DRAMA, 2008, 5, new int[]{7, 13, 13, 13, 16}));
		myList.add(new Series("Stranger Things", Category.SF, 2016, 4, new int[]{8, 9, 8, 9}));
		myList.add(new Series("Friends", Category.COMEDY, 1994, 10, new int[]{24, 24, 25, 24, 24, 25, 24, 24, 24, 18}));
		myList.add(new Series("Dark", Category.THRILLER, 2017, 3, new int[]{10, 8, 8}));
		myList.add(new Series("Rick and Morty", Category.ANIMATION, 2013, 6, new int[]{11, 10, 10, 10, 10, 10}));
		myList.add(new Series("The Office", Category.COMEDY, 2005, 9, new int[]{6, 22, 23, 14, 26, 24, 24, 24, 25}));
		
		String fileName = "mySeries.txt";
		//myList.forEach(x -> x.saveSeries2File(fileName));
		
		List<Series> mySeriesList = Series.readSeriesFromFile(fileName);
		System.out.println("My series list:");
		mySeriesList.forEach(System.out::println);
		
		Series s1 = new Series("Breaking Bad", Category.DRAMA, 2008, 5, new int[]{7,13,13,13,16});
		Series s2 = new Series("Dark", Category.THRILLER, 2017, 3, new int[]{10,8,8});
		Series s3 = new Series("Stranger Things", Category.SF, 2016, 4, new int[]{8,9,8,9});
		Series s4 = new Series("Friends", Category.COMEDY, 1994, 10, new int[]{24,24,25,24,24,25,24,24,24,18});
		Series s5 = new Series("The Office", Category.COMEDY, 2005, 9, new int[]{6,22,23,14,26,24,24,24,25});
		Series s6 = new Series("Dark", Category.THRILLER, 2017, 3, new int[]{10,8,8}); // duplicat logic cu s2
		
		System.out.println("\n=== TreeSet ===");
		Set<Series> treeSet = new TreeSet<>();
		treeSet.add(s1);
		treeSet.add(s2);
		treeSet.add(s3);
		treeSet.add(s4);
		treeSet.add(s5);
		treeSet.add(s6); // nu va fi adăugat dacă equals și compareTo sunt corecte

		for (Series s : treeSet) {
			System.out.println(s);
		}

		// ===================== HashSet =====================
		System.out.println("\n=== HashSet ===");
		Set<Series> hashSet = new HashSet<>();
		hashSet.add(s1);
		hashSet.add(s2);
		hashSet.add(s3);
		hashSet.add(s4);
		hashSet.add(s5);
		hashSet.add(s6); // nu va fi adăugat dacă equals + hashCode sunt implementate corect

		for (Series s : hashSet) {
			System.out.println(s);
		}

		// ===================== TreeMap =====================
		System.out.println("\n=== TreeMap ===");
		Map<String, Series> treeMap = new TreeMap<>();
		treeMap.put(s1.getName(), s1);
		treeMap.put(s2.getName(), s2); // suprascrie dacă numele e identic
		treeMap.put(s3.getName(), s3);
		treeMap.put(s4.getName(), s4);
		treeMap.put(s5.getName(), s5);

		for (Map.Entry<String, Series> entry : treeMap.entrySet()) {
			System.out.println(entry.getKey() + " => " + entry.getValue());
		}

		// ===================== HashMap =====================
		System.out.println("\n=== HashMap ===");
		Map<String, Series> hashMap = new HashMap<>();
		hashMap.put(s1.getName(), s1);
		hashMap.put(s2.getName(), s2);
		hashMap.put(s3.getName(), s3);
		hashMap.put(s4.getName(), s4);
		hashMap.put(s5.getName(), s5);

		for (Map.Entry<String, Series> entry : hashMap.entrySet()) {
			System.out.println(entry.getKey() + " => " + entry.getValue());
		}
	}

}
